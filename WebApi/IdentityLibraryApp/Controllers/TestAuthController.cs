using IdentityLibraryApp.Attributes;
using IdentityLibraryApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityLibraryApp.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]

public class TestAuthController : ControllerBase
{
    //Authentication => Kullanıcı Kontrolü
    //Authorization => Yetki Kontrolü

    //[HttpGet]
    //[TanerAuth("Admin")]
    //public IActionResult TanerAuth()
    //{
    //    return Ok();
    //}

    //[HttpGet]
    //public IActionResult Login()
    //{
    //    return Ok(new { Message = JwtService.CreateToken() });
    //}

    //[HttpGet]
    //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    ////[Role("Admin")]
    //public IActionResult Authorize()
    //{
    //    return Ok();
    //}
}
