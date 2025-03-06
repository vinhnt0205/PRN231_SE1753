using System.Security.Cryptography.Xml;
using WebApp_API_AJAX.Models;
namespace WebApp_API_AJAX.Repositories
{
	public interface IRepository
	{
		IEnumerable<Reservation> Reservations { get; }
		Reservation this[int id] { get; }
		Reservation AddReservation(Reservation reservation);
		Reservation UpdateReservation(Reservation reservation);
		void DeleteReservation(int id);
	}
}
