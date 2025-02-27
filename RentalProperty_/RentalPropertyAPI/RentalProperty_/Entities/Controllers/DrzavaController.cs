using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Entities.ViewModels;

namespace RentalProperty_.Entities.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class DrzavaController : ControllerBase
	{
		private readonly DataContext db;
		public DrzavaController(DataContext dbContext)
		{
			db = dbContext;
		}


		[HttpGet]
		public object GetAll()
		{
			var drzave = db.Drzava.OrderBy(x => x.ID)
				.Select(x => new
				{
					Id = x.ID,
					naziv = x.Naziv
				}).ToList();
			return drzave;
		}
		[HttpGet]

		public object GetSaDodatnimParametromIPretragom(string? naziv)
		{
			var sveDrzave = db.Drzava.OrderBy(x => x.Naziv)
				.Where(x => naziv == null || x.Naziv.ToLower().StartsWith(naziv.ToLower()))
				.Select(x => new DrzavaGetVM
				{
					Id = x.ID,
					Naziv = x.Naziv
				}
				).ToList();

			return sveDrzave;
		}

		[HttpPost]

		public object Add_withParameters(string naziv)
		{
			var novaDrzava = new Drzava
			{
				Naziv = naziv
			};

			db.Add(novaDrzava);
			db.SaveChanges();
			return novaDrzava;
		}


		[HttpPost]

		public Drzava Add([FromBody] DrzavaAddVM x)
		{
			var novadrzava = new Drzava
			{
				Naziv = x.Naziv
			};

			db.Add(novadrzava);
			db.SaveChanges();
			return novadrzava;
		}

	}
}
