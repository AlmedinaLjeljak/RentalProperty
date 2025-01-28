using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Entities.ViewModels;

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
			var sviZapisi = db.Recenzija
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
		[HttpPost]
		public Recenzija Add([FromBody] RecenzijaAddVM x)
		{
			var novi = new Recenzija
			{
				Ime = x.Ime,
				Prezime = x.Prezime,
				Tekst = x.Tekst,
				Slika = x.Slika
			};
			db.Add(novi);
			db.SaveChanges();
			return novi;

		}
	}
}
