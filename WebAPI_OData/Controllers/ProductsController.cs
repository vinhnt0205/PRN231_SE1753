using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebAPI_OData.Data;

namespace WebAPI_OData.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly MyDbContext _context;
		public ProductsController(MyDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		[EnableQuery]
		public IActionResult Get()
		{
			return Ok(_context.Products.AsQueryable());
		}
	}
}
