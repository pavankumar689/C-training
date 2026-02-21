using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "\"Data Source=10.35.0.208;\" +\r\n\"Initial Catalog=College;\" +\r\n\"Integrated Security=True;\" +\r\n\"TrustServerCertificate=True;\";";

        SqlConnection con = new SqlConnection(connectionString);

        SqlDataAdapter adapter =
            new SqlDataAdapter("SELECT * FROM Students", con);

        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

        DataSet ds = new DataSet();

        adapter.Fill(ds, "Students");

        Display(ds);

        ds.Tables["Students"].Rows[0]["Marks"] = 95;

        DataRow newRow = ds.Tables["Students"].NewRow();
        newRow["Id"] = 5;
        newRow["Name"] = "Rahul";
        newRow["Marks"] = 88;
        ds.Tables["Students"].Rows.Add(newRow);

        ds.Tables["Students"].Rows[1].Delete();

        adapter.Update(ds, "Students");

        Console.WriteLine("Database Updated Successfully");
    }

    static void Display(DataSet ds)
    {
        foreach (DataRow row in ds.Tables["Students"].Rows)
        {
            if (row.RowState != DataRowState.Deleted)
            {
                Console.WriteLine($"{row["Id"]} {row["Name"]} {row["Marks"]}");
            }
        }
    }
}