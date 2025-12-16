
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Add API Key and Project URL configuration
var apiKey = builder.Configuration["ApiKey"]; // Assuming ApiKey is stored in appsettings.json
var projectUrl = builder.Configuration["ProjectUrl"]; // Assuming ProjectUrl is stored in appsettings.json

Console.WriteLine("API Key: " + apiKey);
Console.WriteLine("Project URL: " + projectUrl);
