using TestingNewSeleniumAutomationForOneFile.Services;
using Microsoft.OpenApi.Models; // Add this for Swagger

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add MVC services

// Add OpenAPI for Swagger documentation (SwaggerGen)
builder.Services.AddEndpointsApiExplorer(); // Needed for OpenAPI/Swagger UI
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
}); // Add Swagger generator

// Register the NessusAutomationService as Scoped
builder.Services.AddScoped<NessusAutomationService>();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline for OpenAPI documentation (Swagger UI)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger
    app.UseSwaggerUI(); // Enable Swagger UI for API documentation
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Use routing and endpoints for controllers
app.MapControllers(); // Map controller routes

app.Run();
