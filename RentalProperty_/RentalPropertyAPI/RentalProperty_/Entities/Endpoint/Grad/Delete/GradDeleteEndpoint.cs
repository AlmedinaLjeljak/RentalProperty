using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Grad.Delete
{
	[Microsoft.AspNetCore.Mvc.Route("Grad-Delete")]
	public class GradDeleteEndpoint:MyBaseEndpoint<GradDeleteRequest,GradDeleteResponse>
	{
		private readonly DataContext db;

		public GradDeleteEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpDelete]
		public override async Task<GradDeleteResponse> Handle([FromBody] GradDeleteRequest request,CancellationToken cancellationToken)
		{
			var zapis = db.Grad.Where(x => x.Naziv.ToLower() == request.Naziv.ToLower()).FirstOrDefault();
		 
			if(zapis==null)
			{
				throw new Exception("Nije pronadjen grad sa nazivom " + request.Naziv);
			}
			db.Remove(zapis);
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new GradDeleteResponse
			{

			};
		
		
		}

	}
}
