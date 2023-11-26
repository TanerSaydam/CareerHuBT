using BookStoreWebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Controllers;

public class AdminController : ApiController
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetExceptions(CancellationToken cancellationToken)
    {
        var response = await _context.Exceptions.OrderByDescending(p => p.CreatedAt).ToListAsync(cancellationToken);
        return Ok(response);
    }
}

//çay alıp geliyorum 1 2 dk
