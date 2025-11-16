using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Infrastructure.Interfaces;
using TransporteEscolar.Infrastructure.Context;
using TransporteEscolar.Infrastructure.Repositories;
using TransporteEscolar.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar todos los Repositorios
builder.Services.AddScoped<IRutaRepository, RutaRepository>();
builder.Services.AddScoped<IPagoRepository, PagoRepository>();
builder.Services.AddScoped<IHorarioRepository, HorarioRepository>();
builder.Services.AddScoped<IChoferRepository, ChoferRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteRutaRepository, EstudianteRutaRepository>();
builder.Services.AddScoped<IAsistenciaRepository, AsistenciaRepository>();

// Add services to the container.
builder.Services.AddControllers();
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
