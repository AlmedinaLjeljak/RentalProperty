using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Grad.Update
{
	[Microsoft.AspNetCore.Mvc.Route("Grad-Update")]
	public class GradUpdateEndpoint:MyBaseEndpoint<GradUpdateRequest,GradUpdateResponse>
	{
		private readonly DataContext db;

		public GradUpdateEndpoint(DataContext db)
		{
			this.db = db;
		}
		[HttpPatch]
		public override async Task<GradUpdateResponse> Handle([FromBody]GradUpdateRequest request,CancellationToken cancellationToken)
		{
			var grad = db.Grad.Where(x => x.ID == request.Id).FirstOrDefault();

			if(grad==null)
			{
				throw new Exception("Grad ne postoji");
			}
			grad.Naziv = request.Naziv;


			db.Entry(grad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new GradUpdateResponse
			{
				Id = grad.ID
			};
		}

	}
	
}
