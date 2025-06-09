using Microsoft.EntityFrameworkCore;
using PropositionManager.Data;
using PropositionManager.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PropositionManager");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddData(connectionString);
//AddApplicationLayer and QueueDispatcher

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

using var scope = app.Services.CreateScope();
await using var context = scope.ServiceProvider.GetRequiredService<PropositionManagerContext>();
if (context.Database.IsSqlServer())
{
    for (int retries = 0; retries < 5; retries++)
    {
        try
        {
            await context.Database.MigrateAsync();
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database not ready ({ex.Message}), retrying in 5s...");
            await Task.Delay(5000);
        }
    }
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}