using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Entities.Endpoint.FAQ.GetAll;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Tfa.GetAll
{
	[Route("Tfa-GetAll")]
	public class TfaGetAllEndpoint: MyBaseEndpoint<TfaGetAllRequest,TfaGetAllResponse>
	{
		private readonly DataContext db;

		public TfaGetAllEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public override async Task<TfaGetAllResponse> Handle([FromQuery] TfaGetAllRequest request, CancellationToken cancellationToken)
		{
			var lastTwoFKeys = await db.AutentifikacijaToken
				.GroupBy(x => x.KorisnickiNalogId)
				.Select(group => new
				{
					KorisnickiNalogId = group.Key,
					LastTwoFKey = group.OrderByDescending(x => x.id).Select(x => x.TwoFKey).FirstOrDefault()
				})
			.ToListAsync(cancellationToken);

			var tfas = lastTwoFKeys.Select(x => new TfaGetallResponseRow
			{
				Id = x.KorisnickiNalogId,
				TwoKey = x.LastTwoFKey
			}).ToList();

			return new TfaGetAllResponse
			{
				Tfas = tfas
			};
		}
	}
}
