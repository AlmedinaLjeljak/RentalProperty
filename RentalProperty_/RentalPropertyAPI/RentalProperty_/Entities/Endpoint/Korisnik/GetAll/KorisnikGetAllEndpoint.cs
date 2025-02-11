using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Korisnik.GetAll
{
	[Microsoft.AspNetCore.Mvc.Route("Korisnik-GetAll")]
	public class KorisnikGetAllEndpoint:MyBaseEndpoint<KorisnikGetallRequest,KorisnikGetallResponse>
	{
		private readonly DataContext db;

		public KorisnikGetAllEndpoint(DataContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public override async Task<KorisnikGetallResponse> Handle([FromBody] KorisnikGetallRequest request,CancellationToken cancellationToken)
		{
			var korisnici = await db.Korisnik
				.Select(x => new KorisnikGetAllResponseRow
				{
					Id = x.ID,
					Ime = x.Ime,
					Prezime = x.Prezime,
					Username = x.Username,
					Password = x.Password,
					Slika = x.Slika,
					NazivGrada=x.Grad.Naziv,
					NazivSpol=x.Spol.Naziv,
					NazivDrzave=x.Drzava.Naziv,
					BrojTelefona=x.BrojTelefona,
					GradId=x.GradID,
					SpolId=x.SpolID,
					DrzavaId=x.DrazavaID
				}).ToListAsync(cancellationToken: cancellationToken);

			return new KorisnikGetallResponse
			{
				Korisnici = korisnici
			};
		}
	}
}
