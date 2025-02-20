using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebAPI_OData_Demo2.Model;

namespace WebAPI_OData_Demo2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly BookStoreContext _context;
		public BookController(BookStoreContext context)
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

		[EnableQuery(PageSize = 1)]
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_context.Books.AsQueryable());
		}

		[EnableQuery]
		[HttpPost]
		public IActionResult Post([FromBody] Book book)
		{
			_context.Books.Add(book);
			_context.SaveChanges();
			return Created("Created: ", book);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			if(id <= 0)
			{
				return BadRequest();
			}
			var book = _context.Books.Find(id);
			if(book == null)
			{
				return NotFound();
			}
			return Ok(book);
		}
		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Book book)
		{
			if(id <= 0)
			{
				return BadRequest();
			}
			var entity = _context.Books.Find(id);
			if(entity == null)
			{
				return NotFound();
			}
			entity.Title = book.Title;
			entity.Author = book.Author;
			entity.ISBN = book.ISBN;
			entity.Price = book.Price;
			entity.Location = book.Location;
			entity.Press = book.Press;
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
			var book = _context.Books.Find(id);
			if(book == null)
			{
				return NotFound();
			}
			_context.Books.Remove(book);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
