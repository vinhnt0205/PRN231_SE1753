using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI_Binding_Routing_Validation.Mapper;
using WebAPI_Binding_Routing_Validation.Models;
using WebAPI_Binding_Routing_Validation.Repositories;
using WebAPI_Binding_Routing_Validation.Repositories.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddSingleton(new MapperConfiguration(mc =>
{
	mc.AddProfile(new MappingProfile());
}).CreateMapper());


// Build the service provider.
var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
