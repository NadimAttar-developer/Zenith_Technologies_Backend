using MySql.Data.MySqlClient;
using Test.Database;

namespace Test.Services;

public class ProductService : ITestService<Product>
{
    private readonly IConfiguration _configuration;

    public ProductService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Product> GetData()
    {
        var products = new List<Product>();

        using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();

            using (var command = new MySqlCommand("SELECT * FROM Products", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]) ?? string.Empty,
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Price = Convert.ToDecimal(reader["Price"])
                    };

                    products.Add(product);
                }
            }
        }

        return products;
    }

}
