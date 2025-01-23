using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;

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
			var sviZapisi = db.Spols.OrderBy(x => x.ID)
				.Select(x => new
				{
					id = x.ID,
					naziv = x.Naziv
				}).ToList();
			return sviZapisi;
		}
	}
}
