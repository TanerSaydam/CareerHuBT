using DependencyInjection.Context;
using DependencyInjection.Controllers;
using DependencyInjection.Middleware;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<Product>();
builder.Services.AddSingleton<Product>(); //dependenjcy injection
//builder.Services.AddSingleton<Product>();
builder.Services.AddTransient<ExceptionMiddleware>();


builder.Services.Scan(selector => selector
    .FromAssemblies(
    typeof(InfrastructureAssembly).Assembly
    )
    .AddClasses(publicOnly: false)
    .UsingRegistrationStrategy(registrationStrategy: Scrutor.RegistrationStrategy.Skip)
    .AsMatchingInterface()
    .WithScopedLifetime());

builder.Services.AddDbContext<AppDbContext>(opt=>
{
    opt.UseSqlServer("Data Source=DESKTOP-3BJ5GK9\\SQLEXPRESS;Initial Catalog=BookStoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
