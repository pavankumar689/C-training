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
            SqlDataAdapter da =
                new SqlDataAdapter("SELECT Id, Name, Marks FROM Student", con);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();

            da.Fill(ds, "Student");

            DataTable dt = ds.Tables["Student"];

            dt.Rows[0]["Marks"] = 95;

            DataRow newRow = dt.NewRow();
            newRow["Id"] = 5;
            newRow["Name"] = "Ravi";
            newRow["Marks"] = 88;
            dt.Rows.Add(newRow);

            da.Update(ds, "Student");

            Console.WriteLine("Changes updated successfully");
        }

        Console.ReadLine();
    }
}