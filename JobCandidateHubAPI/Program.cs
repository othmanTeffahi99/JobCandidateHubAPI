using System.Reflection;
using FluentValidation;
using JobCandidateHubAPI.Commons.DataBase;
using JobCandidateHubAPI.Commons.ExceptionHandler;
using JobCandidateHubAPI.Commons.Validations;
using JobCandidateHubAPI.DataContext;
using JobCandidateHubAPI.EndPoints;
using JobCandidateHubAPI.Entities;
using JobCandidateHubAPI.Repositories;
using JobCandidateHubAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
	opt.UseInMemoryDatabase("JobCandidateDb").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	opt.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IValidator<Candidate>, CandidateValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((context, configuration) =>
	configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.MapCandidateEndPoints();


SeedData.PrepareSeedData(app);
app.Run();

