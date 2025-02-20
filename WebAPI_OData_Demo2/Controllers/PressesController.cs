using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebAPI_OData_Demo2.Model;

namespace WebAPI_OData_Demo2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PressesController : ControllerBase
	{
		private readonly BookStoreContext _context;
		public PressesController(BookStoreContext context)
		{
			_context = context;
			if(_context.Books.Count() == 0)
			{
				foreach(var book in DataSource.GetBooks())
				{
					context.Books.Add(book);
					context.Presses.Add(book.Press);
				}
				context.SaveChanges();
			}
		}

		[EnableQuery, HttpGet]
		public IActionResult Get()
		{
			return Ok(_context.Presses.AsQueryable());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			if(id <= 0)
			{
				return BadRequest();
			}
			var press = _context.Presses.Find(id);
			if(press == null)
			{
				return NotFound();
			}
			return Ok(press);
		}

		[HttpPost]
		public IActionResult Insert([FromBody] Press press)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest();
			}
			_context.Presses.Add(press);
			_context.SaveChanges();
			return Created("Created: ", press);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Press press)
		{
			if(id <= 0)
			{
				return BadRequest();
			}
			var entity = _context.Presses.Find(id);
			if(entity == null)
			{
				return NotFound();
			}
			entity.Name = press.Name;
			entity.Email = press.Email;
			entity.Category = press.Category;
			_context.SaveChanges();
			return Ok(entity);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if(id <= 0)
			{
				return BadRequest();
			}
			var press = _context.Presses.Find(id);
			if(press == null)
			{
				return NotFound();
			}
			_context.Presses.Remove(press);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
