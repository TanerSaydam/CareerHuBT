using DefaultCorsPolicyNugetPackage;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OgrenciSinavSistemiServer.WebApi.Context;
using OgrenciSinavSistemiServer.WebApi.Models;
using OgrenciSinavSistemiServer.WebApi.Options;
using OgrenciSinavSistemiServer.WebApi.Repositories;
using OgrenciSinavSistemiServer.WebApi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));

string? connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    var secretKey = builder.Configuration.GetSection("Jwt:SecretKey").Value;
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
            secretKey ?? ""))
    };
});

builder.Services.AddDefaultCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

using (var scoped = app.Services.CreateScope())
{
    var context = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!context.Users.Any())
    {
        context.Users.Add(new User()
        {
            Name = "Taner Saydam",
            UserName = "taner",
            IsTeacher = true,
        });
        context.SaveChanges();
    }   
}

app.UseAuthorization();

app.MapControllers();

app.Run();
