using System.Data;
using System.Data.SqlClient;
public class Program
{
    static string connectionString =
               "Data Source=PAVAN\\SQLEXPRESS;" +
               "Initial Catalog=Company;" +
               "Integrated Security=True;" +
               "TrustServerCertificate=True;";
    static void GetEmployeesByDepartment(string dept)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Department", dept);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["EmpId"]} {dr["Name"]} {dr["Department"]} {dr["Phone"]} {dr["Email"]}");
            }
        }
    }
    static void GetDepartmentEmployeeCount(string dept)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetDepartmentEmployeeCount", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Department", dept);

            SqlParameter output = new SqlParameter("@TotalCount", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(output);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine($"Total employees in {dept}: {output.Value}");
        }
    }
    static void GetEmployeeOrders()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmployeeOrders", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["Name"]} {dr["Department"]} {dr["OrderId"]} {dr["OrderAmount"]} {dr["OrderDate"]}");
            }
        }
    }
    static void GetDuplicateEmployees()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetDuplicateEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["EmpId"]} {dr["Name"]} {dr["Phone"]} {dr["Email"]}");
            }
        }
    }
    static void Main()
    {
        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        Console.WriteLine("\nEmployees:");
        GetEmployeesByDepartment(dept);

        Console.WriteLine("\nDepartment Count:");
        GetDepartmentEmployeeCount(dept);

        Console.WriteLine("\nEmployee Orders:");
        GetEmployeeOrders();

        Console.WriteLine("\nDuplicate Employees:");
        GetDuplicateEmployees();
    }
}