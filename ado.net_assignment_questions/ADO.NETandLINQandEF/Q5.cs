using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        int Id = 1;
        string Name = "Arun";
        int Marks = 90;

        string conStr =
            "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
            "Initial Catalog=MyDatabase;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        using (SqlConnection con = new SqlConnection(conStr))
        {
            try
            {
                string query =
                    "INSERT INTO Student (Id, Name, Marks) VALUES (@Id, @Name, @Marks)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Marks", Marks);

                    con.Open();

                    int rows = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rows} row inserted successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:");
                Console.WriteLine(ex.Message);
            }
        }

        Console.ReadLine();
    }
}