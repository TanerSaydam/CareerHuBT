using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Context;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models;
using OgrenciSinavSistemiServer.WebApi.Services;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        string? token = await userService.LoginAsync(request, cancellationToken); 
        return Ok(new { AccessToken= token });
    }
}
