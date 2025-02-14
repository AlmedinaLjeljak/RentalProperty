using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Recenzija.Add
{
	[Microsoft.AspNetCore.Mvc.Route("Recednzija-Add")]
	[MyAuthorization]
	public class RecenzijaAddEndpoint:MyBaseEndpoint<RecenzijaAddRequest,RecenzijaAddResponse>
	{
		private readonly DataContext db;

		public RecenzijaAddEndpoint(DataContext db)
		{
			this.db = db;
		}
		[HttpPost]
		public override async Task<RecenzijaAddResponse> Handle([FromBody]RecenzijaAddRequest request,CancellationToken cancellationToken)
		{
			var novi = new Entities.Models.Recenzija
			{
				Ime = request.Ime,
				Prezime = request.Prezime,
				Slika = request.Slika,
				Tekst = request.Tekst,
			};
			db.Recenzija.Add(novi);
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new RecenzijaAddResponse
			{
				Id = novi.Id,
				Ime = novi.Ime,
				Prezime = novi.Prezime
			};
		}

	}
}
