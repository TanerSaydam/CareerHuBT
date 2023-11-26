using BookStoreWebApi.Context;
using BookStoreWebApi.Exceptions;
using Newtonsoft.Json;

namespace BookStoreWebApi.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    private readonly AppDbContext _context;

    public ExceptionMiddleware(AppDbContext context)
    {
        _context = context;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            Models.Exception exception = new()
            {
                CreatedAt = DateTime.Now,
                InnerException = ex.InnerException?.Message,
                StackTrace = ex.StackTrace,
                Message = ex.Message,
                Path = context.Request.Path
            };

            await _context.Exceptions.AddAsync(exception);
            await _context.SaveChangesAsync();

            context.Response.ContentType = "application/json";
            int statusCode = 500;
            if (ex.GetType() == typeof(UserNotFoundException))
            {
                statusCode = 404;
            }
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = ex.Message }));
        }
    }
}