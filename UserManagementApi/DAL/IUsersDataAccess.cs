namespace UserManagementApi.DAL;

using UserManagementApi.Model;

public interface IUsersDataAccess
{
    Task<List<User>> GetAllUsersAsync();
    Task SaveNewUserAsync(User user);
    Task DeleteUserByIdAsync(int id);
    Task UpdateUserAsync(int id, User user);
}
