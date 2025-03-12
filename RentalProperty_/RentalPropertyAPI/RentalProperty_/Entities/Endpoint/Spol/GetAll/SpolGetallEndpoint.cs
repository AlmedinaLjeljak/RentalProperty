using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Spol.GetAll
{
	[Route("Spol-GetAll")]
	public class SpolGetallEndpoint: MyBaseEndpoint<SpolGetAllRequest,SpolGetAllResponse>

	{
		private readonly DataContext db;
		
		public SpolGetallEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public override async Task<SpolGetAllResponse> Handle([FromQuery]SpolGetAllRequest request,CancellationToken cancellationToken)
		{
			var spolovi = await db.Spol
				.Select(x => new SpolGetAllResponseRow
				{
					Id=x.ID,
					Naziv=x.Naziv

				}).ToListAsync(cancellationToken: cancellationToken);

			return new SpolGetAllResponse
			{
				Spolovi = spolovi
			};
		
		
		}
	}
}
