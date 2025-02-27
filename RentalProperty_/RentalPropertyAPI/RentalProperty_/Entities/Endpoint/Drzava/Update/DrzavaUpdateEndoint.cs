using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Endpoint.Grad.Update;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Drzava.Update
{
	[Route("Drzava-Update")]
	public class DrzavaUpdateEndpoint : MyBaseEndpoint<DrzavaUpdateRequest, DrzavaUpdateResponse>
	{
		private readonly DataContext db;

		public DrzavaUpdateEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpPatch]
		public override async Task<DrzavaUpdateResponse> Handle([FromBody] DrzavaUpdateRequest request, CancellationToken cancellationToken)
		{
			var drzava = db.Drzava.Where(x => x.ID == request.ID).FirstOrDefault();

			if (drzava == null)
			{
				throw new Exception("Drzava ne postoji");
			}

			drzava.Naziv = request.Naziv;



			db.Entry(drzava).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new DrzavaUpdateResponse
			{
				ID = drzava.ID
			};
		}

	}
}
