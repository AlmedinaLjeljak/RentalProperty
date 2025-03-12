using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Authentification.Login
{

	[Microsoft.AspNetCore.Mvc.Route("Autentifikacija")]
	public class AutentifikacijaLoginEndpoint : MyBaseEndpoint<AutentifikacijaLoginRequest, MyAuthInfo>
	{
		private readonly DataContext _applicationDbContext;
		private readonly MyEmailSenderService _emailSenderService;

		public AutentifikacijaLoginEndpoint(DataContext applicationDbContext, MyEmailSenderService emailSenderService)
		{
			_applicationDbContext = applicationDbContext;
			_emailSenderService = emailSenderService;
		}

		[HttpPost("Login")]
		public override async Task<MyAuthInfo> Handle([FromBody] AutentifikacijaLoginRequest request, CancellationToken cancellationToken)
		{
			//1- provjera logina
			KorisnickiNalog? logiraniKorisnik = await _applicationDbContext.KorisnickiNalog
				.FirstOrDefaultAsync(k =>
					k.Username == request.Username && k.Password == request.Password, cancellationToken);

			if (logiraniKorisnik == null)
			{
				//pogresan username i password
				return new MyAuthInfo(null);
			}

			string? TwoFKey = null;

			if (logiraniKorisnik.is2FActive)
			{
				TwoFKey = TokenGenerator.Generate(4);
				_emailSenderService.Posalji("testiram.gms@gmail.com", "2 faktor autentifikacija", $"Vaš 2F ključ je {TwoFKey}", false);
			}

			//2- generisati random string
			string randomString = TokenGenerator.Generate(10);

			//3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
			var noviToken = new AutentifikacijaToken()
			{
				ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
				vrijednost = randomString,
				korisnickiNalog = logiraniKorisnik,
				vrijemeEvidentiranja = DateTime.Now,
				TwoFKey = TwoFKey
			};

			_applicationDbContext.Add(noviToken);
			await _applicationDbContext.SaveChangesAsync(cancellationToken);

			//4- vratiti token string
			return new MyAuthInfo(noviToken);
		}


	}
}