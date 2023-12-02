using IdentityLibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace IdentityLibraryApp.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register()
    {
        
        AppUser appUser = new()
        {
            Email = "tanersaydam@gmail.com",
            UserName = "tsaydam2",
            PhoneNumber = "111",
        };

        IdentityResult result = await userManager.CreateAsync(appUser, "1");
        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors.FirstOrDefault());
        
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request)
    {
        AppUser? user = await userManager.FindByNameAsync(request.Username);
        if(user is null)
        {
            return BadRequest(new { Message = "Kullanıcı bulunamadı!" });
        }

        SignInResult result = await signInManager.PasswordSignInAsync(user,request.Password,true,true);

        if (result.IsLockedOut)
        {
            return BadRequest(new { Message = $"Şifrenizi 3 kere yanlış girdiğiniz için uygulamanız 30 sn kilitlenmiştir. Lütfen 30 sn sonra tekrar deneyiniz!" });
        }

        if (!result.Succeeded)
        {
            return BadRequest(new { Message = "Şifre yanlış" });
        }

       
        return Ok();
    }
}

public sealed record LoginDto(string Username, string Password);
