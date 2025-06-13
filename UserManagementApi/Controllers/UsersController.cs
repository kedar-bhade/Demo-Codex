using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.DAL;
using UserManagementApi.Model;

namespace UserManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUsersDataAccess _dataAccess;

    public UsersController(ILogger<UsersController> logger, IUsersDataAccess dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
    }

    [HttpGet]
    [EnableCors]
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _dataAccess.GetAllUsersAsync();
    }

    [HttpPost]
    [EnableCors]
    public async Task<IActionResult> InsertNewUser(User user)
    {
        await _dataAccess.SaveNewUserAsync(user);
        return Ok(new { message = "User created" });
    }

    [HttpDelete("{id}")]
    [EnableCors]
    public async Task<IActionResult> DeleteOneUser(int id)
    {
        await _dataAccess.DeleteUserByIdAsync(id);
        return Ok(new { message = "User deleted" });
    }

    [HttpPut("{id}")]
    [EnableCors]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    {
        await _dataAccess.UpdateUserAsync(id, user);
        return Ok(new { message = "User updated" });
    }
}
