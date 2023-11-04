
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TrabajadoresPrueba.BLL.Service;
using TrabajadoresPrueba.DAL;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TrabajadoresPruebaContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));
builder.Services.AddScoped<IGenericRepository<Trabajadores>, TrabajadoresRepository>();
builder.Services.AddScoped<ITrabajadoresService, TrabajadoresService>();

builder.Services.AddSingleton(new Conexion(builder.Configuration.GetConnectionString("cadenaSQL")));

builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

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
