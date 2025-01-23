using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;

namespace RentalProperty_.Entities.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class KorisniciController:ControllerBase
	{
		private readonly DataContext db;

		public KorisniciController(DataContext dbContext)
		{
			this.db = dbContext;
		}

		[HttpGet]
		public object GetAll()
		{
			var sviKorisnici = db.Korisniks.Include("Spol").Include("Grad").Include("Drzava").OrderBy(x => x.ID)
				.Select(x => new
				{
					id = x.ID,
					ime = x.Ime,
					prezime = x.Prezime,
					username = x.Username,
					password = x.Password,
					slika = x.Slika,
					brojTelefona = x.BrojTelefona,
					grad = x.Grad,
					spol = x.Spol,
					drzava = x.Drzava

				}).AsQueryable();
			return sviKorisnici.ToList();

		}
	}
}
