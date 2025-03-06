using Microsoft.AspNetCore.Mvc;

namespace WebApp_API_AJAX.Controllers
{
	public class ReservationsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
