using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Entities.Endpoint.Grad.GetAll;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Drzava.GetAll
{
	[Microsoft.AspNetCore.Mvc.Route("Drzava-GetAll")]
	public class DrzavaGetAllEndpoint : MyBaseEndpoint<DrzavaGetAllRequest, DrzavaGetAllResponse>
	{
		private readonly DataContext db;

		public DrzavaGetAllEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public override async Task<DrzavaGetAllResponse> Handle([FromBody] DrzavaGetAllRequest request, CancellationToken cancellationToken)
		{
			var drzave = await db.Drzava
				.Select(x => new DrzavaGetAllResponseRow
				{
					ID = x.ID,
					Naziv = x.Naziv,
				}).OrderBy(x => x.Naziv).ToListAsync(cancellationToken: cancellationToken);

			return new DrzavaGetAllResponse
			{
				Drzave = drzave
			};
		}
	}
}
