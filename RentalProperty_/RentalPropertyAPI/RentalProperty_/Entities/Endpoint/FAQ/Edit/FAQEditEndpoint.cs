using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.FAQ.Edit
{
	[Microsoft.AspNetCore.Mvc.Route("FAQ-Edit")]
	[MyAuthorization]
	public class FAQEditEndpoint:MyBaseEndpoint<FAQEditRequest,int>
	{
		private readonly DataContext db;
		public FAQEditEndpoint(DataContext db)
		{
			this.db = db;
		}
		[HttpPost]
		public override async Task<int> Handle([FromBody]FAQEditRequest request,CancellationToken cancellationToken)
		{
			Models.FAQ? FAQ;
			if(request.ID==0)
			{
				FAQ = new Models.FAQ();
				db.Add(FAQ);
			}
			else
			{
				FAQ = db.FAQ.FirstOrDefault(s => s.Id == request.ID);
				if (FAQ == null)
					throw new Exception("Pogresan ID");
			}
			FAQ.Pitanje = request.Pitanje.RemoveTags();
			FAQ.Odgovor = request.Odgovor.RemoveTags();

			await db.SaveChangesAsync(cancellationToken);
			return FAQ.Id;
		}
	}
}
