using MySql.Data.MySqlClient;
using Test.Database;

namespace Test.Services;

public class UserService : ITestService<User>
{
    private readonly IConfiguration _configuration;

    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<User> GetData()
    {
        var users = new List<User>();

        using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();

            using (var command = new MySqlCommand("SELECT * FROM Users", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var user = new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = Convert.ToString(reader["FirstName"]) ?? string.Empty,
                        LastName = Convert.ToString(reader["LastName"]) ?? string.Empty,
                        Age = Convert.ToInt32(reader["Age"]),
                        MobileNumber = Convert.ToString(reader["MobileNumber"]) ?? string.Empty
                    };

                    users.Add(user);
                }
            }
        }

        return users;
    }
}
