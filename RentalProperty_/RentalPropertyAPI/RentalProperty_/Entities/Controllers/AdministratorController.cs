using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Entities.ViewModels;

namespace RentalProperty_.Entities.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class AdministratorController:ControllerBase
	{
		private readonly DataContext db;
		public AdministratorController(DataContext dbContext)
		{
			db = dbContext;
		}
		[HttpGet]
		
		public object GetAll()
		{
			var zapisi = db.Administrator
				.Select(x => new
				{
					Id = x.ID,
					Username = x.Username,
					Password = x.Password,
					Ime = x.Ime,
					Prezime = x.Prezime
				}).ToList();
			return zapisi;
		}
		[HttpPost]
		public Administrator Add([FromBody]AdministratorAddVM x)
		{
			var novi = new Administrator
			{
				Username = x.Username,
				Password = x.Password
			};
			db.Add(novi);
			db.SaveChanges();
			return novi;
		}

		
	}
}
