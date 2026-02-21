using System;
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

        int senderAcc = 1;
        int receiverAcc = 2;
        int amount = 500;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                string deductQuery =
                    "UPDATE Account SET Balance = Balance - @amt WHERE AccNo = @sender";

                SqlCommand cmd1 = new SqlCommand(deductQuery, con, transaction);
                cmd1.Parameters.AddWithValue("@amt", amount);
                cmd1.Parameters.AddWithValue("@sender", senderAcc);
                cmd1.ExecuteNonQuery();

                string addQuery =
                    "UPDATE Account SET Balance = Balance + @amt WHERE AccNo = @receiver";

                SqlCommand cmd2 = new SqlCommand(addQuery, con, transaction);
                cmd2.Parameters.AddWithValue("@amt", amount);
                cmd2.Parameters.AddWithValue("@receiver", receiverAcc);
                cmd2.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Transaction Successful");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Transaction Failed - Rolled Back");
                Console.WriteLine(ex.Message);
            }
        }

        Console.ReadLine();
    }
}