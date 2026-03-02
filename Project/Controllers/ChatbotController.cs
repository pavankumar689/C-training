using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// Empower Admin Chatbot System
// Allows natural language querying of the SQL database via Google Gemini

namespace EmployeeApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ChatbotController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public ChatbotController(IConfiguration config)
        {
            _config = config;
            _httpClient = new HttpClient();
        }

        [HttpPost("ask")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Ask([FromBody] ChatRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Message)) 
                return Ok(new { response = "Please ask me a question!" });

            string apiKey = _config["GeminiApiKey"];
            if (string.IsNullOrEmpty(apiKey))
                return Ok(new { response = "<span class='text-danger'>Google Gemini API Key is missing. Please add it to your <code>appsettings.json</code> as <code>GeminiApiKey</code> to enable AI features.</span>" });

            try 
            {
                // 1. Text to SQL Phase
                string schema = @"Table: Employees
Columns:
- Id (INT, Primary Key)
- Name (NVARCHAR)
- Aadhaar (NVARCHAR)
- Address (NVARCHAR)
- DateOfBirth (DATETIME2)
- JoiningDate (DATETIME2)
- Salary (DECIMAL)

Rules for SQL generation:
1. Return ONLY a valid SQL Server query.
2. Do NOT format with markdown (no ```sql tags). Just raw text.
3. Do NOT include any explanations or apologies.
4. The query must only SELECT data.
5. Example: Question: 'who has highest salary?' -> Output: SELECT TOP 1 Name, Salary FROM Employees ORDER BY Salary DESC";

                string promptToSQL = $"{schema}\n\nQuestion: {req.Message}\nSQL Query Output:";
                string sqlQuery = await CallGeminiAsync(promptToSQL, apiKey);
                sqlQuery = CleanSQL(sqlQuery);

                if (string.IsNullOrWhiteSpace(sqlQuery) || sqlQuery.StartsWith("Sorry"))
                {
                    return Ok(new { response = "I couldn't understand how to query that information from the database." });
                }

                if (sqlQuery.ToLower().Contains("delete ") || sqlQuery.ToLower().Contains("update ") || sqlQuery.ToLower().Contains("insert ") || sqlQuery.ToLower().Contains("drop "))
                {
                    return Ok(new { response = "<i class=\"bi bi-shield-x text-danger\"></i> Query blocked for security reasons." });
                }

                // 2. Fetch Data from Database
                var connString = _config.GetConnectionString("DefaultConnection");
                await using var conn = new SqlConnection(connString);
                await conn.OpenAsync();
                
                await using var cmd = new SqlCommand(sqlQuery, conn);
                var dataResult = new StringBuilder();

                try 
                {
                    await using var reader = await cmd.ExecuteReaderAsync();
                    
                    var columns = new List<string>();
                    for (int i=0; i < reader.FieldCount; i++) columns.Add(reader.GetName(i));
                    dataResult.AppendLine(string.Join(" | ", columns));

                    int count = 0;
                    while(await reader.ReadAsync() && count < 50)
                    {
                        var rowVals = new List<string>();
                        for (int i=0; i<reader.FieldCount; i++) 
                        {
                            var val = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString();
                            rowVals.Add(val);
                        }
                        dataResult.AppendLine(string.Join(" | ", rowVals));
                        count++;
                    }

                    if (count == 0) dataResult.AppendLine("No data was found for this query.");
                }
                catch (Exception sqlEx)
                {
                    Console.WriteLine("SQL error: " + sqlEx.Message);
                    dataResult.AppendLine($"Error running query: {sqlEx.Message}");
                }

                // 3. Summarize SQL Results into Natural Language
                string summarizePrompt = $@"You are the Empower AI Chatbot Assistants, helping a company Administrator.
The administrator asked: ""{req.Message}""

I searched the database and obtained this raw data:
---
{dataResult.ToString()}
---

Task rules:
1. Provide a friendly, concise answer to the administrator based ONLY on the data provided above.
2. Use safe HTML formatting (<strong>, <ul>, <li>, <br>) so it renders nicely in a chat widget.
3. DO NOT return markdown (no `**` or `##`), and DO NOT wrap your output in ```html or backticks. Return the raw HTML.
4. DO NOT mention SQL, tables, columns, or the database process. Just give them the answer naturally like a human assistant.";

                string finalResponse = await CallGeminiAsync(summarizePrompt, apiKey);

                // Strip any accidental markdown formatting if Gemini ignores instructions
                if (finalResponse.StartsWith("```html")) finalResponse = finalResponse.Substring(7);
                if (finalResponse.StartsWith("```")) finalResponse = finalResponse.Substring(3);
                if (finalResponse.EndsWith("```")) finalResponse = finalResponse.Substring(0, finalResponse.Length - 3);

                return Ok(new { response = finalResponse.Trim() });
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Chatbot Error: {ex.Message}");
                return Ok(new { response = "An error occurred while talking to the AI. Check logs for details: " + ex.Message });
            }
        }

        [HttpPost("userask")]
        [Authorize] // Standard users can access this
        public async Task<IActionResult> UserAsk([FromBody] ChatRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Message)) 
                return Ok(new { response = "Please ask me a question!" });

            string apiKey = _config["GeminiApiKey"];
            if (string.IsNullOrEmpty(apiKey))
                return Ok(new { response = "<span class='text-danger'>Google Gemini API Key is missing.</span>" });

            try 
            {
                string prompt = $@"You are the Empower AI HR Assistant.
Your job is to answer employee questions about company policies according to this handbook excerpt:

- Paid Time Off (PTO): Full-time employees accrue 20 days of paid time off per calendar year. New hires accrue PTO at a rate of 1.66 days per month.
- Sick Leave: Employees receive 10 days of paid sick leave annually. Unused sick leave rolls over up to 30 days.
- Holidays: Empower observes 12 public holidays.
- Working Hours: Standard is 9-5 MF. Core hours are 10-3 for flex schedules.
- Remote Work: Up to 3 days remote with manager approval.
- Dress Code: Smart casual. Business attire for clients.

The employee asks: ""{req.Message}""

Task rules:
1. Provide a friendly, helpful HR answer.
2. If the employee asks about something NOT in the handbook, politely say you don't have that information and they should contact HR.
3. Use safe HTML formatting (<strong>, <ul>, <li>, <br>) so it renders nicely in a chat widget.
4. DO NOT return markdown (no `**` or `##`), and DO NOT wrap your output in ```html.";

                string finalResponse = await CallGeminiAsync(prompt, apiKey);

                if (finalResponse.StartsWith("```html")) finalResponse = finalResponse.Substring(7);
                if (finalResponse.StartsWith("```")) finalResponse = finalResponse.Substring(3);
                if (finalResponse.EndsWith("```")) finalResponse = finalResponse.Substring(0, finalResponse.Length - 3);

                return Ok(new { response = finalResponse.Trim() });
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Chatbot Error: {ex.Message}");
                return Ok(new { response = "An error occurred while talking to the AI. Check logs for details: " + ex.Message });
            }
        }

        private async Task<string> CallGeminiAsync(string prompt, string apiKey)
        {
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[] { new { text = prompt } }
                    }
                }
            };

            string jsonBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";
            
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Gemini API error ({response.StatusCode}): {error}");
            }

            string resultJson = await response.Content.ReadAsStringAsync();
            dynamic rawObj = JsonConvert.DeserializeObject(resultJson);
            
            string output = rawObj?.candidates?[0]?.content?.parts?[0]?.text;
            return output ?? "";
        }

        private string CleanSQL(string rawText)
        {
            if (string.IsNullOrWhiteSpace(rawText)) return "";
            
            var txt = rawText.Trim();
            if (txt.StartsWith("```sql")) txt = txt.Substring(6);
            if (txt.StartsWith("```")) txt = txt.Substring(3);
            if (txt.EndsWith("```")) txt = txt.Substring(0, txt.Length - 3);
            
            return txt.Trim();
        }
    }

    public class ChatRequest { public string Message { get; set; } }
}
