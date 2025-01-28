using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Entities.ViewModels;

namespace RentalProperty_.Entities.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class FAQController:ControllerBase
	{
		private readonly DataContext db;
		public FAQController(DataContext dbContext)
		{
			db = dbContext;
		}
		[HttpGet]
		public object GetAll()
		{
			var zapisi = db.FAQ
				.Select(x => new
				{
					id = x.Id,
					pitanje = x.Pitanje,
					odgovor = x.Odgovor
				}).ToList();
			return zapisi;
		}
		[HttpPost]
		public FAQ Add([FromBody]FAQAddVM x)
		{
			var novi = new FAQ
			{
				Pitanje = x.Pitanje,
				Odgovor = x.Odgovor
			};
			db.Add(novi);
			db.SaveChanges();
			return novi;
		}
	}
}
