using question.Models;
using System.Data.SqlClient;
using global::question.Models;
namespace question.Data
{
    public class studentrepository
    {
        private readonly string _connectionString;

        public studentrepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Name, Age, City FROM StudentsMaster";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = (int)reader["Age"],
                        City = reader["City"].ToString()
                    });
                }
            }

            return students;
        }
    }
}
