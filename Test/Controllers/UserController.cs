using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Test.Database;
using Test.Services;

namespace Test.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ITestService<User> _userService;

    public UserController(ITestService<User> userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var users = _userService.GetData();

        return Ok(users);
    }
}
