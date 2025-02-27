using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Endpoint.Grad.Add;
using RentalProperty_.Helper.Auth;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Drzava.Add
{
	[Microsoft.AspNetCore.Mvc.Route("Drzava-Add")]
	[MyAuthorization]
	public class DrzavaAddEndpoint : MyBaseEndpoint<DrzavaAddRequest, DrzavaAddResponse>
	{
		private readonly DataContext db;
		private readonly MyAuthService auth;

		public DrzavaAddEndpoint(DataContext db, MyAuthService auth)
		{
			this.db = db;
			this.auth = auth;
		}

		[HttpPost]
		public override async Task<DrzavaAddResponse> Handle([FromBody] DrzavaAddRequest request, CancellationToken cancellationToken)
		{
			var novi = new Entities.Models.Drzava
			{
				Naziv = request.Naziv
			};
			db.Drzava.Add(novi);
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new DrzavaAddResponse
			{
				Id = novi.ID,
				Naziv = novi.Naziv
			};

		}



	}
}
