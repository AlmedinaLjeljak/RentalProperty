using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.FAQ.Add
{
	[Microsoft.AspNetCore.Mvc.Route("FAQ-Add")]
	[MyAuthorization]
	public class FAQAddEndpoint:MyBaseEndpoint<FAQAddRequest,FAQAddResponse>
	{
		private readonly DataContext db;
		private readonly MyAuthService auth;
		public FAQAddEndpoint(DataContext db,MyAuthService auth)
		{
			this.db = db;
			this.auth = auth;
		}
		[HttpPost]
		public override async Task<FAQAddResponse> Handle([FromBody]FAQAddRequest request,CancellationToken cancellationToken)
		{
			var novi = new Entities.Models.FAQ
			{
				Pitanje = request.Pitanje,
				Odgovor = request.Odgovor

			};
			db.FAQ.Add(novi);
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new FAQAddResponse
			{
				ID = novi.Id,
			};
		}
	}
}
