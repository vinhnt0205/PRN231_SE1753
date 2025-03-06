using System.Text.Json.Serialization;
using WebApp_API_AJAX.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRepository, Repository>();

builder.Services.AddControllersWithViews()
	.AddXmlDataContractSerializerFormatters()
	.AddJsonOptions(opt =>
	{
		opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		opt.JsonSerializerOptions.WriteIndented = true;
	});
builder.Services.AddControllers();
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
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
