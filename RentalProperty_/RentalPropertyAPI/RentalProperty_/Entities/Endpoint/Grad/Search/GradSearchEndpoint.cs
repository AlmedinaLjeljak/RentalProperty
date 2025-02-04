using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Grad.Search
{
	[Microsoft.AspNetCore.Mvc.Route("Grad-Search")]
	public class GradSearchEndpoint:MyBaseEndpoint<GradSearchRequest,GradSearchResponse>
	{
		private readonly DataContext db;

		public GradSearchEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public override async Task<GradSearchResponse> Handle([FromBody]GradSearchRequest request,CancellationToken cancellationToken)
		{
			var gradovi = await db.Grad.Where(x => request.Naziv == null
			|| x.Naziv.ToLower().StartsWith(request.Naziv.ToLower())).Select(x => new GradSearchResponseDodatak
			{
				Id=x.ID,
				Naziv=x.Naziv

			}).ToListAsync(cancellationToken: cancellationToken);

			return new GradSearchResponse
			{
				Gradovi = gradovi
			};
		}
	}
}
