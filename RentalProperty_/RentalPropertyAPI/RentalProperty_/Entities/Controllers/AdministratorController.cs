﻿using Microsoft.AspNetCore.Mvc;
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
			var zapisi = db.KorisnikAgent
				.Select(x => new
				{
					korisnikId = x.KorisnikId,
					agentId = x.AgentId,
					datumTermina = x.DatumTermina,
					vrijemeSati = x.VrijemeSat
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
