using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Recenzija.GetAll
{
	[Route("Recenzija-GetAll")]

	public class RecenzijaGetAllEndpoint : MyBaseEndpoint<RecenzijaGetAllRequest, RecenzijaGetallResponse>
	{
		private readonly DataContext db;

		public RecenzijaGetAllEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public override async Task<RecenzijaGetallResponse> Handle([FromQuery] RecenzijaGetAllRequest request, CancellationToken cancellationToken)
		{
			var recenzija = await db.Recenzija
				 .Select(x => new RecenzijaGetallResponseRow
				 {
					 Id = x.Id,
					 Ime = x.Ime,
					 Prezime = x.Prezime,
					 Tekst = x.Tekst,
					 Slika = x.Slika
				 }).ToListAsync(cancellationToken: cancellationToken);

			return new RecenzijaGetallResponse
			{
				Recenzije = recenzija
			};
		}
	}
}
