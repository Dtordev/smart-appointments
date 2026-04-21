using SmartAppointments.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProjectServices(builder.Configuration);

var app = builder.Build();

app.UseProjectMiddleware();

app.Run();
