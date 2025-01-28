using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Entities.ViewModels;

namespace RentalProperty_.Entities.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class Gradcontroller:ControllerBase
	{
		private readonly DataContext db;
		public Gradcontroller(DataContext dbContext)
		{
			db = dbContext;
		}


		[HttpGet]
		public object GetAll()
		{
			var gradovi = db.Grad.OrderBy(x => x.ID)
				.Select(x => new
				{
					Id = x.ID,
					naziv = x.Naziv
				}).ToList();
			return gradovi;
		}
		[HttpGet]

		public object GetSaDodatnimParametromIPretragom(string? naziv) 
		{
			var sviGradovi = db.Grad.OrderBy(x => x.Naziv)
				.Where(x => naziv == null || x.Naziv.ToLower().StartsWith(naziv.ToLower()))
				.Select(x => new GradGetVM
				{
					Id = x.ID,
					Naziv = x.Naziv
				}
				).ToList();

			return sviGradovi;
		}

		[HttpPost]

		public object Add_withParameters(string naziv)
		{
			var noviGrad = new Grad
			{
				Naziv = naziv
			};

			db.Add(noviGrad);
			db.SaveChanges();
			return noviGrad;
		}


		[HttpPost]

		public Grad Add([FromBody] GradAddVM x)
		{
			var noviGrad = new Grad
			{
				Naziv = x.Naziv
			};

			db.Add(noviGrad);
			db.SaveChanges();
			return noviGrad;
		}

	}
}
