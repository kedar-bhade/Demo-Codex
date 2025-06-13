using MySql.Data.MySqlClient;
using UserManagementApi.Model;

namespace UserManagementApi.DAL;

public class UsersDataAccess : IUsersDataAccess
{
    private readonly string _connectionString;
    private readonly ILogger<UsersDataAccess> _logger;

    public UsersDataAccess(IConfiguration configuration, ILogger<UsersDataAccess> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        _logger = logger;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = new List<User>();
        try
        {
            using var con = new MySqlConnection(_connectionString);
            await con.OpenAsync();
            using var cmd = new MySqlCommand("select * from users", con);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var user = new User
                {
                    UserId = reader.GetFieldValue<int>(reader.GetOrdinal("userid")),
                    Username = reader.GetFieldValue<string>(reader.GetOrdinal("username")),
                    Course = reader.GetFieldValue<string>(reader.GetOrdinal("course")),
                    PurchaseDate = reader.GetFieldValue<string>(reader.GetOrdinal("purchasedate"))
                };
                users.Add(user);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving users");
        }
        return users;
    }

    public async Task SaveNewUserAsync(User user)
    {
        try
        {
            using var con = new MySqlConnection(_connectionString);
            await con.OpenAsync();
            const string query = "insert into users(username, course, purchasedate) values(@username,@course,@purchasedate)";
            using var cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@course", user.Course);
            cmd.Parameters.AddWithValue("@purchasedate", user.PurchaseDate);
            await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving user");
        }
    }

    public async Task DeleteUserByIdAsync(int id)
    {
        try
        {
            using var con = new MySqlConnection(_connectionString);
            await con.OpenAsync();
            const string query = "delete from users where userid=@id";
            using var cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user {UserId}", id);
        }
    }

    public async Task UpdateUserAsync(int id, User user)
    {
        try
        {
            using var con = new MySqlConnection(_connectionString);
            await con.OpenAsync();
            const string query = "update users set username=@username, course=@course, purchasedate=@purchasedate where userid=@id";
            using var cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@course", user.Course);
            cmd.Parameters.AddWithValue("@purchasedate", user.PurchaseDate);
            cmd.Parameters.AddWithValue("@id", id);
            await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user {UserId}", id);
        }
    }
}
