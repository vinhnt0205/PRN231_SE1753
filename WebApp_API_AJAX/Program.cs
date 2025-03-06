using System.Text.Json.Serialization;
using WebApp_API_AJAX.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddCors();
builder.Services.AddControllersWithViews()
	.AddXmlDataContractSerializerFormatters()
	.AddJsonOptions(opt =>
	{
		opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		opt.JsonSerializerOptions.WriteIndented = true;
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
