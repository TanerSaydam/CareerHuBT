using DefaultCorsPolicyNugetPackage;
using OgrenciSinavSistemiServer.WebApi.Context;
using OgrenciSinavSistemiServer.WebApi.Extensions;
using OgrenciSinavSistemiServer.WebApi.Models.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddContext(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddAuthenticationDI(builder.Configuration);

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

app.MapControllers();

app.Run();
