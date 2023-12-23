using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Users;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController(IAuthService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        ErrorOr<string?> errorOr = await userService.LoginAsync(request, cancellationToken);

        if (errorOr.IsError)
        {
            return BadRequest(errorOr.FirstError);
        }

        var response = new ResponseDto<string>() { Data = errorOr.Value };

        return Ok(response);
    }    
}
