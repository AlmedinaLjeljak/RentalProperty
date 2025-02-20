using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Tfa.GetAll
{
	[Route("Tfa-GetAll")]
	public class TfaGetAllEndpoint: MyBaseEndpoint<TfaGetAllRequest,TfaGetAllResponse>
	{
		private readonly DataContext db;

		public TfaGetAllEndpoint(DataContext db )
		{
			this.db = db;
		}
		[HttpGet]
		public override async Task<TfaGetAllResponse> Handle([FromBody]TfaGetAllRequest request,CancellationToken cancellationToken)
		{
			var lastTwoKeys = await db.AutentifikacijaToken
				.GroupBy(x => x.KorisnickiNalogId)
				.Select(group => new
				{
					KorisnickiNalogId = group.Key,
					LastTwoKeys = group.OrderByDescending(x => x.id).Select(x => x.TwoFKey).FirstOrDefault()
				}).ToListAsync(cancellationToken);

			var tfas = lastTwoKeys.Select(x => new TfaGetallResponseRow
			{
				Id = x.KorisnickiNalogId,
				TwoKey = x.LastTwoKeys
			}).ToList();

			return new TfaGetAllResponse
			{
				Tfas = tfas
			};
		
		}
	}
}
