using System.Collections.Generic;
using System.Data.SqlClient;

public class ProductDAL
{
    string connectionString =
        "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
        "Initial Catalog=MyDatabase;" +
        "Integrated Security=True;" +
        "TrustServerCertificate=True;";

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT ProductId, ProductName, Price FROM Product";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product p = new Product();

                        p.ProductId = Convert.ToInt32(reader["ProductId"]);
                        p.ProductName = reader["ProductName"].ToString();
                        p.Price = Convert.ToDecimal(reader["Price"]);

                        products.Add(p);
                    }
                }
            }
        }

        return products;
    }
}