using FastEndpoints;
using FastEndpoints.Swagger;
using TrainReservation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddTrainReservation();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
