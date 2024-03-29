using e_Commerce.WebHooks.Api.Configuration;
using e_Commerce.WebHooks.Infrastructure.Configuration;
using e_Commerce.WebHooks.Infrastructure.Logging.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfiguration(builder.Configuration);
builder.UseSerilog();
var app = builder.Build();
app.UseInfrastructure();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}