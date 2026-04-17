using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SmartAppointments.Application.Interfaces.Repositories;
using SmartAppointments.Application.Interfaces.Services;
using SmartAppointments.Application.Services;
using SmartAppointments.Infrastructure.Data;
using SmartAppointments.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IArchivoService, ArchivoService>();
builder.Services.AddScoped<IArchivoRepository, ArchivoRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Api | Documentation")
               .WithTheme(ScalarTheme.DeepSpace);
    });
}

app.Run();
