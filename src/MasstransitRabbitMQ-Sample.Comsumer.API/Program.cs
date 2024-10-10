using MasstransitRabbitMQ_Sample.Comsumer.API.DependencyInjection.Extensions;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
//add serilog configuration


Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging
    .ClearProviders()
    .AddSerilog();

builder.Host.UseSerilog();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//add masstransit configuration

builder.Services.AddconfigureMasstractionRabbitMQ(builder.Configuration);

//add mediatR 
builder.Services.AddMediatR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
