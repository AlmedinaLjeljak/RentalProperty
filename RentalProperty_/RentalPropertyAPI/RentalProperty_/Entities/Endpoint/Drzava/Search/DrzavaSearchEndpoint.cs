using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Entities.Endpoint.Grad.Search;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Drzava.Search
{
	[Microsoft.AspNetCore.Mvc.Route("Drzava-Search")]
	public class DrzavaSearchEndpoint : MyBaseEndpoint<DrzavaSearchRequest, DrzavaSearchResponse>
	{
		private readonly DataContext db;

		public DrzavaSearchEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public override async Task<DrzavaSearchResponse> Handle([FromBody] DrzavaSearchRequest request, CancellationToken cancellationToken)
		{
			var drzave = await db.Drzava.Where(x => request.Naziv == null
			|| x.Naziv.ToLower().StartsWith(request.Naziv.ToLower())).Select(x => new DrzavaSearchResponseDodatak
			{
				Id = x.ID,
				Naziv = x.Naziv

			}).ToListAsync(cancellationToken: cancellationToken);

			return new DrzavaSearchResponse
			{
				Drzave = drzave
			};
		}
	}
}
