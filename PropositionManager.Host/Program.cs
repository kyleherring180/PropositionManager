using Microsoft.EntityFrameworkCore;
using PropositionManager.Data;
using PropositionManager.Data.Extensions;
using Asp.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PropositionManager");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Proposition Manager API", Version = "v1" });
});

builder.Services.AddData(connectionString);
//AddApplicationLayer and QueueDispatcher

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
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
app.MapControllers(); 

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}