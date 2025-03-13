using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Korisnik.Add
{
	[Microsoft.AspNetCore.Mvc.Route("Korisnik-Add")]
	//[MyAuthorization]
	public class KorisnikAddEndpoint:MyBaseEndpoint<KorisnikAddRequest,KorisnikAddResponse>
	{
		private readonly DataContext db;
		public KorisnikAddEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpPost]
		public override async Task<KorisnikAddResponse> Handle([FromBody]KorisnikAddRequest request,CancellationToken cancellationToken)
		{
			var novi = new Entities.Models.Korisnik
			{
				Ime = request.Ime,
				Prezime = request.Prezime,
				Username = request.Username,
				Password = request.Password,
				Slika = request.Slika,
				BrojTelefona = request.BrojTelefona,
				GradID = request.GradID,
				DrazavaID = request.DrzavaId,
				SpolID = request.SpolId
			};
			db.Korisnik.Add(novi);
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new KorisnikAddResponse
			{
				Id = novi.ID,
				Ime = novi.Ime,
				Prezime = novi.Prezime,
				Username = novi.Username,
				Password = novi.Password
			};
		}
	}
}
