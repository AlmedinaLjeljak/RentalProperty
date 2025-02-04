using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Grad.Add
{
	[Microsoft.AspNetCore.Mvc.Route("Grad-Add")]
	[MyAuthorization]
	public class GradAddEnpoint:MyBaseEndpoint<GradAddRequest,GradAddResponse>
	{
		private readonly DataContext db;
		private readonly MyAuthService auth;

		public GradAddEnpoint(DataContext db,MyAuthService auth)
		{
			this.db = db;
			this.auth = auth;
		}

		[HttpPost]
		public override async Task<GradAddResponse> Handle([FromBody]GradAddRequest request,CancellationToken cancellationToken)
		{
			var novi = new Entities.Models.Grad
			{
				Naziv = request.Naziv
			};
			db.Grad.Add(novi);
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new GradAddResponse
			{
				ID = novi.ID,
				Naziv = novi.Naziv
			};
		
		}



	}
}
