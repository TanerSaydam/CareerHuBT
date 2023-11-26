using Microsoft.AspNetCore.Mvc;

namespace DockerSolution.TestWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Api Çalışıyor!" });
    }
}
