using BookStoreWebApi.Context;
using BookStoreWebApi.Middleware;
using BookStoreWebApi.Models;
using BookStoreWebApi.Options;
using BookStoreWebApi.Utilities;
using Iyzipay;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(p =>
    {
        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.Configure<Options>(builder.Configuration.GetSection("Iyzipay")); //Options pattern 1
builder.Services.AddOptions<Options>().BindConfiguration("IyziPay").ValidateDataAnnotations().ValidateOnStart(); //Options pattern 2


string connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
}); //depnendency injection - service registration
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

//builder.Services.ConfigureOptions<JwtOptions>(); //service registration
builder.Services
    .AddOptions<Jwt>()
    .Bind(builder.Configuration.GetSection("Jwt"))
    .ValidateDataAnnotations() //validation kurallar�n� denetler
    .ValidateOnStart();
builder.Services.ConfigureOptions<JwtOptionsSetup>(); //service registration

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
//json web token => �ifrelenmi� bir anahtar �retiyor.
//authentication => kullan�c� kontrol�
//Authorization => kulan�c� yetki kontrol�
builder.Services.CreateService();
builder.Services.AddTransient<ExceptionMiddleware>(); //AddScoped //AddSingleton
//Exception middleware dependency injection ile beraber instance t�retmem laz�m
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();  

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    bool result = userManager.Users.Any(p => p.IsAdmin == true);
    if (!result)
    {
        var adminUser = new AppUser()
        {
            UserName = "admin",
            Email = "admin@admin.com",
            IsAdmin = true,
            NameLastname = "Taner Saydam"
        };

        userManager.CreateAsync(adminUser, "Admin123*").Wait();
    }
}

app.Run();