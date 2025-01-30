using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.FAQ.GetAll
{
	[Route("FAQ-GetAll")]

	public class FAQGetAllEndpoint : MyBaseEndpoint<FAQGetAllRequest, FAQGetAllResponse>
	{
		private readonly DataContext db;

		public FAQGetAllEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public override async Task<FAQGetAllResponse> Handle([FromQuery] FAQGetAllRequest request, CancellationToken cancellationToken)
		{
			var faq = await db.FAQ
				.Select(x => new FAQGetAllResponseRow
				{
					ID = x.Id,
					Pitanje = x.Pitanje,
					Odgovor = x.Odgovor


				}).ToListAsync(cancellationToken: cancellationToken);

			return new FAQGetAllResponse
			{
				FAQ = faq
			};
		}
	}

}
