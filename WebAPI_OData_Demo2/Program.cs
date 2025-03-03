using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using WebAPI_OData_Demo2.Model;

static IEdmModel GetModel()
{
	var builder = new ODataConventionModelBuilder();
	builder.EntitySet<Book>("Book");
	builder.EntitySet<Press>("Presses");
	return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(opt => opt.Select().Count().Filter().OrderBy().SetMaxTop(100).AddRouteComponents("odata", GetModel()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreContext>(options =>
{
	options.UseInMemoryDatabase("BookLists");
});

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
