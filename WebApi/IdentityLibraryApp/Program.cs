using IdentityLibraryApp.Attributes;
using IdentityLibraryApp.Context;
using IdentityLibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options=>
{
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 1;

	options.User.RequireUniqueEmail = true;

	options.Lockout.MaxFailedAccessAttempts = 3;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(20);
	options.Lockout.AllowedForNewUsers = true;

}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddJwtBearer(options=>
{
	options.TokenValidationParameters = new()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateIssuerSigningKey = true,
		ValidateLifetime = true,
		ValidIssuer = "Taner Saydam",
		ValidAudience = "Taner Saydam",
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam "))
	};
});
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
	try
	{
		await next(context);
	}
	catch (Exception ex)
	{
			
		if(ex.GetType() == typeof(UnAuthentication))
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = 401;

			await context.Response.WriteAsync(ex.ToString());
		} 

		throw;
	}
});

using (var scoped = app.Services.CreateScope())
{
	ApplicationDbContext context = new();
	context.Database.Migrate();
}

app.MapControllers();

app.Run();
