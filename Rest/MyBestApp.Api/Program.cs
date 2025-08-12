using MyBestApp.Api.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .BasicConfiguration()
    .AddSwaggerSupport()
    .Build();

app.UseSerilogRequestLogging();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();
