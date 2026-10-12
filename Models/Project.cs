using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Haal de ConnectionString op en registreer DbContext via Dependency Injection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Voeg controllers en Swagger services toe
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Activeer Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 4. Koppel de controller routes
app.MapControllers();

app.Run();