using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
    //GET POST PUT DELETE PATCH OPTIONS
    [HttpGet]
    public IActionResult Get(int id, string name, string password)
    {
        return Ok(new {Message = "Api isteği başarılı"});
    }

    [HttpPost]
    public IActionResult Post(Login login)
    {
        return Ok(new { Message = "Api isteği başarılı" });
    }
}

public class Login
{
    public string Name { get; set; }
    public string Password { get; set; }
}