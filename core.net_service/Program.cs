using Microsoft.EntityFrameworkCore;
using Data.DTO;
using Data.Repositories;
using Domain.UseCase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OperacionesEntity>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOperacionRepository, OperacionRepository>();

builder.Services.AddScoped<CreateOperacionUseCase>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Health check endpoint for deployment services
app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }));

app.MapControllers();

app.Run();
