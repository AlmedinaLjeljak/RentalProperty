using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Entities.ViewModels;

namespace RentalProperty_.Entities.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class SpolController:ControllerBase
	{
		private readonly DataContext db;
		public SpolController(DataContext dbContext)
		{
			db = dbContext;
		}

		[HttpGet]
		public object GetAll()
		{
			var sviZapisi = db.Spol.OrderBy(x => x.ID)
				.Select(x => new
				{
					id = x.ID,
					naziv = x.Naziv
				}).ToList();
			return sviZapisi;
		}
		[HttpPost]
		public Spol Add([FromBody] SpolAddVM x)
		{
			var novi = new Spol
			{
				Naziv = x.Naziv
			};
			db.Add(novi);
			db.SaveChanges();
			return novi;
		}
	}
}
