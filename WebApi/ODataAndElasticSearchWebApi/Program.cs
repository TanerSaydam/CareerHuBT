using DefaultCorsPolicyNugetPackage;
using Microsoft.AspNetCore.OData;
using ODataAndElasticSearchWebApi.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCors();

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddControllers().AddOData(options=>
{
    options.EnableQueryFeatures();
});
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

app.UseAuthorization();

app.MapControllers();

app.Run();
