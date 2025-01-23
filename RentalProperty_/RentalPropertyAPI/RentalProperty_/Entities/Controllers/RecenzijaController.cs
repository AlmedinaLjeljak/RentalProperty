using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;

namespace RentalProperty_.Entities.Controllers
{

	[ApiController]
	[Route("[controller]/[action]")]
	public class RecenzijaController:ControllerBase
	{
		private readonly DataContext db;
		public RecenzijaController(DataContext dbContext)
		{
			db = dbContext;
		}

		[HttpGet]
		public object GetAll()
		{
			var sviZapisi = db.Recenzijas
				.Select(x => new
				{
					id = x.Id,
					ime = x.Ime,
					prezime = x.Prezime,
					tekst = x.Tekst,
					slika = x.Slika

				}).ToList();
			return sviZapisi;
		}
		
	}
}
