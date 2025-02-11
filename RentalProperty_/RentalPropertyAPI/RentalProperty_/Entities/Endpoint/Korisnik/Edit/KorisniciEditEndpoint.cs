using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Korisnik.Edit
{
	[Microsoft.AspNetCore.Mvc.Route("Korisnik-Edit")]
	[MyAuthorization]
	public class KorisniciEditEndpoint:MyBaseEndpoint<KorisniciEditRequest,int>
	{
		private readonly DataContext db;
		public KorisniciEditEndpoint(DataContext db)
		{
			this.db = db;
		}
		[HttpPost]
		public override async Task<int> Handle([FromBody]KorisniciEditRequest request,CancellationToken cancellationToken)
		{
			Models.Korisnik? korisnik;
			if(request.Id==0)
			{
				korisnik = new Models.Korisnik();
				db.Add(korisnik);
			}
			else
			{
				korisnik = db.Korisnik.FirstOrDefault(s => s.ID == request.Id);
				if (korisnik == null)
					throw new Exception("pogresan id");
			}
			korisnik.Ime = request.Ime.RemoveTags();
			korisnik.Prezime = request.Prezime.RemoveTags();
			korisnik.Username = request.Username.RemoveTags();
			korisnik.Password = request.Password.RemoveTags();
			korisnik.Slika = request.Slika?.RemoveTags();
			korisnik.BrojTelefona = request.BrojTelefona.RemoveTags();
			korisnik.GradID = request.GradId;
			korisnik.SpolID = request.SpolId;
			korisnik.DrazavaID = request.DrzavaId;

			await db.SaveChangesAsync(cancellationToken);
			return korisnik.ID;
		
		}

	}
}
