using FlightAssistant.API.Middlewares;
using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Services;
using FlightAssistant.Core.Settings;
using FlightAssistant.Data;
using FlightAssistant.Data.Repositories;
using FlightAssistant.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AmadeusSettings>(builder.Configuration.GetSection("Amadeus"));
builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("Cache"));

builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddSingleton<IAmadeusConfigService, AmadeusConfigService>();

builder.Services.AddTransient<IAirportRepository, AirportRepository>();
builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddTransient<IFlightRepository, FlightRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Flight_Assistant_DB")));

builder.Services.AddTransient<IAirportService, AirportService>();
builder.Services.AddTransient<ICurrencyService, CurrencyService>();
builder.Services.AddTransient<IFlightService, FlightService>();
builder.Services.AddTransient<IAmadeusApiService, AmadeusApiService>();

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
