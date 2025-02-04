using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Grad.GetAll
{
	[Microsoft.AspNetCore.Mvc.Route("Grad-GetAll")]
	public class GradGetAllEndpoint:MyBaseEndpoint<GradGetAllRequest,GradGetAllResponse>
	{
		private readonly DataContext db;

		public GradGetAllEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public override async Task<GradGetAllResponse> Handle([FromBody]GradGetAllRequest request,CancellationToken cancellationToken)
		{
			var gradovi = await db.Grad
				.Select(x => new GradGetAllResponseRow
				{
					Id = x.ID,
					Naziv = x.Naziv,
				}).OrderBy(x => x.Naziv).ToListAsync(cancellationToken: cancellationToken);

			return new GradGetAllResponse
			{
				Gradovi = gradovi
			};
		}
	}
}
