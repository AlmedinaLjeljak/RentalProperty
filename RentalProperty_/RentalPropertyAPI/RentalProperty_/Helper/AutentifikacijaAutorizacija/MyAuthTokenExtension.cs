﻿using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using System.Text.Json.Serialization;

namespace RentalProperty_.Helper.AutentifikacijaAutorizacija
{
	public static class MyAuthTokenExtension
	{
		public class LoginInformacije
		{
			public LoginInformacije(AutentifikacijaToken? autentifikacijaToken)
			{
				this.autentifikacijaToken = autentifikacijaToken;
			}

			[JsonIgnore]
			public KorisnickiNalog? korisnickiNalog => autentifikacijaToken?.korisnickiNalog;
			public AutentifikacijaToken? autentifikacijaToken { get; set; }

			public bool isLogiran => korisnickiNalog != null;

		}


		public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
		{
			var token = httpContext.GetAuthToken();

			return new LoginInformacije(token);
		}

		public static AutentifikacijaToken? GetAuthToken(this HttpContext httpContext)
		{
			string token = httpContext.GetMyAuthToken();
			 DataContext db = httpContext.RequestServices.GetService<DataContext>();

			AutentifikacijaToken? korisnickiNalog = db.AutentifikacijaToken
				.Include(s => s.korisnickiNalog)
				.SingleOrDefault(x => x.vrijednost == token);

			return korisnickiNalog;
		}


		public static string GetMyAuthToken(this HttpContext httpContext)
		{
			string token = httpContext.Request.Headers["autentifikacija-token"];
			return token;
		}
	}
}
