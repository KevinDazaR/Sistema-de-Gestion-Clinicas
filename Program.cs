using Simulacro2.Data;
using Simulacro2.Services.Pacientes;
using Simulacro2.Services.Especialidades;
using Simulacro2.Services.Medicos;
using Simulacro2.Services.Citas;
using Simulacro2.Services.Emails;
using Simulacro2.Services.Tratamientos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Important


builder.Services.AddDbContext<BaseContext>(Options =>
    Options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("(8.0.20-mysql")
        ));


builder.Services.AddScoped<IPacientesRepository, PacientesRepository>(); // Important
builder.Services.AddScoped<IEspecialidadesRepository, EspecialidadesRepository>(); // Important
builder.Services.AddScoped<IMedicosRepository, MedicosRepository>(); // Important
builder.Services.AddScoped<ICitasRepository, CitasRepository>(); // Important
//builder.Services.AddHttpClient<IMailRepository, MailRepository>();
builder.Services.AddScoped<ITratamientosRepository, TratamientosRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapControllers(); // important
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
