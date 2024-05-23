using DataLayer;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Agregar servicios al contenedor
builder.Services.AddSingleton(new TrabajadoresDL(connectionString));
builder.Services.AddScoped<TrabajadoresBL>();

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
