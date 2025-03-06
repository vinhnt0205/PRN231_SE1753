using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApp_API_AJAX.Models;
using WebApp_API_AJAX.Repositories;

namespace WebApp_API_AJAX.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationController : ControllerBase
	{
		private readonly IRepository _repository;
		private readonly IWebHostEnvironment _hostingEnvironment;
		public ReservationController(IRepository repository, IWebHostEnvironment hostingEnvironment)
		{
			_repository = repository;
			_hostingEnvironment = hostingEnvironment;
		}
		[HttpGet]
		public IEnumerable<Reservation> Get()
		{
			return _repository.Reservations;
		}
		[HttpGet("{id}")]
		public ActionResult<Reservation> Get(int id)
		{
			if(id <= 0)
			{
				return BadRequest("Value must be passed in the request body");
			}
			return Ok(_repository[id]);
		}
		[HttpPost]
		public Reservation Post([FromBody] Reservation reservation)
		{
			return _repository.AddReservation(new Reservation
			{
				Name = reservation.Name,
				StartLocation = reservation.StartLocation,
				EndLocation = reservation.EndLocation
			});
		}
		[HttpPut]
		public Reservation Put([FromBody] Reservation reservation)
		{
			return _repository.UpdateReservation(reservation);
		}
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_repository.DeleteReservation(id);
		}
		bool Authenticate()
		{
			var allowedKeys = new[] { "Secret@123", "Secret#12", "SecretABC" };
			StringValues key = Request.Headers["Key"];
			int count = (from t in allowedKeys where t == key select t).Count();
			return count == 0 ? false : true;
		}
		[HttpPost("PostXml")]
		[Consumes("application/xml")]
		public Reservation PostXml([FromBody] System.Xml.Linq.XElement res)
		{
			return _repository.AddReservation(new Reservation
			{
				Name = res.Element("Name").Value,
				StartLocation = res.Element("StartLocation").Value,
				EndLocation = res.Element("EndLocation").Value
			});
		}
		[HttpGet("ShowReservation. {format}"), FormatFilter]
		public IEnumerable<Reservation> ShowReservation() => _repository.Reservations;
	}
}
