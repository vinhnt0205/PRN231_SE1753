using AutoMapper;
using WebAPICodeFirst;
using WebAPICodeFirst.DB;
using WebAPICodeFirst.Services.InstrumentTypeServices;
using WebAPICodeFirst.Services.PlayerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseService(builder.Configuration.GetConnectionString("DB"));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperConfig());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IInstumentTypeService, InstrumentTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();
