using Npgsql;
using Onyx.Application;
using Onyx.Domain.Enums;
using Onyx.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    #region Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
    #endregion
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();