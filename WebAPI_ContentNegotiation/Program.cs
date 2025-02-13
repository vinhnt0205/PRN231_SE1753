using Microsoft.AspNetCore.Mvc.Formatters;
using WebAPI_ContentNegotiation.CustomFormatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option =>
{
    option.OutputFormatters.Add(new CsvOutputFormatter());
    option.OutputFormatters.Add(new XmlSerializerOutputFormatter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
