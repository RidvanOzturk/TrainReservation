using FastEndpoints;
using FastEndpoints.Swagger;
using TrainReservation.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddApplication();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen(); 

app.Run();
