var builder = WebApplication.CreateBuilder(args);

// 1. Voeg controllers en Swagger services toe
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Activeer Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 3. Koppel de controller routes
app.MapControllers();

app.Run();