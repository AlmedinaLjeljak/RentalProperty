using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;

namespace RentalProperty_.Entities.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class TfaController : ControllerBase
	{
		private readonly DataContext db;
		public TfaController(DataContext dbContext)
		{
			db = dbContext;
		}

		[HttpGet]

		public object GetAll()
		{
			var sviZapisi = db.AutentifikacijaToken
				.Select(x => new
				{
					ID = x.KorisnickiNalogId,
					TwoFKey = x.TwoFKey
				}
				).ToList();

			return sviZapisi;
		}
	}
}
