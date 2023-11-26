using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
}
