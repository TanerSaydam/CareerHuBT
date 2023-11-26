using BookStoreWebApi.Authentication;
using BookStoreWebApi.Dtos;
using BookStoreWebApi.Exceptions;
using BookStoreWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Controllers;

public class AuthController : ApiController
{
    private readonly UserManager<AppUser> _userManager;

    public AuthController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (user == null) throw new UserNotFoundException();
        }

        bool passwordCheck = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordCheck) throw new PasswordIsWrongException();

        var response = JwtProvider.CreateToken(user);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
    {
        var isEmailExist = await _userManager.Users.AnyAsync(p => p.Email == request.Email, cancellationToken);
        if (isEmailExist)
            throw new ThisEmailAlreadyTakenException();

        AppUser user = new()
        {
            Email = request.Email,
            NameLastname = request.NameLastname,
            UserName = request.UserName
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded) throw new UserCannotCreatedException(result.Errors.FirstOrDefault());

        var response = JwtProvider.CreateToken(user);
        return Ok(response);
    }
}