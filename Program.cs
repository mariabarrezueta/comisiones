using MiniCoreComision.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar CORS para permitir solicitudes desde Angular (puerto 4200)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Asegúrate que el puerto sea correcto
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware de Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Activar CORS antes de MapControllers
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

