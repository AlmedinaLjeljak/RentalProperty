using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;

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
	}
}
