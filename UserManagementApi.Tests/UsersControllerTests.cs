using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UserManagementApi.Controllers;
using UserManagementApi.DAL;
using UserManagementApi.Model;

namespace UserManagementApi.Tests;

[TestFixture]
public class UsersControllerTests
{
    private UsersController _controller = null!;
    private Mock<IUsersDataAccess> _dataAccessMock = null!;

    [SetUp]
    public void Setup()
    {
        _dataAccessMock = new Mock<IUsersDataAccess>();
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<UsersController>();
        _controller = new UsersController(logger, _dataAccessMock.Object);
    }

    [Test]
    public async Task GetAllUsers_ReturnsUsers()
    {
        var users = new List<User> { new() { UserId = 1, Username = "test", Course = "c", PurchaseDate = "2024" } };
        _dataAccessMock.Setup(d => d.GetAllUsersAsync()).ReturnsAsync(users);

        var result = await _controller.GetAllUsers();

        Assert.AreEqual(users, result.ToList());
    }

    [Test]
    public async Task InsertNewUser_ReturnsOk()
    {
        var user = new User { Username = "name", Course = "course", PurchaseDate = "date" };

        var result = await _controller.InsertNewUser(user) as OkObjectResult;

        _dataAccessMock.Verify(d => d.SaveNewUserAsync(user), Times.Once);
        Assert.NotNull(result);
        var message = result!.Value!.GetType().GetProperty("message")?.GetValue(result.Value);
        Assert.AreEqual("User created", message);
    }

    [Test]
    public async Task DeleteOneUser_ReturnsOk()
    {
        var result = await _controller.DeleteOneUser(42) as OkObjectResult;

        _dataAccessMock.Verify(d => d.DeleteUserByIdAsync(42), Times.Once);
        Assert.NotNull(result);
        var message = result!.Value!.GetType().GetProperty("message")?.GetValue(result.Value);
        Assert.AreEqual("User deleted", message);
    }

    [Test]
    public async Task UpdateUser_ReturnsOk()
    {
        var user = new User { Username = "name", Course = "course", PurchaseDate = "date" };

        var result = await _controller.UpdateUser(7, user) as OkObjectResult;

        _dataAccessMock.Verify(d => d.UpdateUserAsync(7, user), Times.Once);
        Assert.NotNull(result);
        var message = result!.Value!.GetType().GetProperty("message")?.GetValue(result.Value);
        Assert.AreEqual("User updated", message);
    }
}
