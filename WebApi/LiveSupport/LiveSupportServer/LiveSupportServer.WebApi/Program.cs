using LiveSupportServer.Application;
using LiveSupportServer.Infrastructure;
using LiveSupportServer.Infrastructure.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(cfr =>
{
    cfr
        .AddDefaultPolicy(policy =>
            policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(policy => true));
});

builder.Services.AddApplication();
builder.Services.AddInfrasturcture(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<CreateRoomHub>("/create-room-hub");

app.Run();