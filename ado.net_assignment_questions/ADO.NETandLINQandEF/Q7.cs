using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
            "Initial Catalog=MyDatabase;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeCount", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter outputParam =
                    new SqlParameter("@EmpCount", SqlDbType.Int);

                outputParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outputParam);

                cmd.ExecuteNonQuery();

                int count = (int)cmd.Parameters["@EmpCount"].Value;

                Console.WriteLine($"Employee Count: {count}");
            }
        }

        Console.ReadLine();
    }
}