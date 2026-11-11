using Catalogo.Api.Data; // Cambiado: Ahora apunta a tu carpeta Data de Catálogo
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurado con tu contexto de catálogo y la nueva cadena de conexión
builder.Services.AddDbContext<CatalogoDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CatalogoConnection")
    ));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
