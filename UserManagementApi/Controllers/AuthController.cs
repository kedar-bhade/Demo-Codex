using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using UserManagementApi.Model;
using UserManagementApi.DAL;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    [EnableCors()]
    public IActionResult Register(Credential cred)
    {
        CredentialsDataAccess.RegisterUser(cred);
        return Ok(new { message = "User registered" });
    }

    [HttpPost("login")]
    [EnableCors()]
    public IActionResult Login(Credential cred)
    {
        bool valid = CredentialsDataAccess.ValidateUser(cred);
        if (valid)
            return Ok(new { message = "Login successful" });
        else
            return Unauthorized();
    }
}
