using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Endpoint.Grad.Delete;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Drzava.Delete
{
	[Microsoft.AspNetCore.Mvc.Route("Drzava-Delete")]
	public class DrzavaDeleteEndpoint : MyBaseEndpoint<DrzavaDeleteRequest, DrzavaDeleteResponse>
	{
		private readonly DataContext db;

		public DrzavaDeleteEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpDelete]
		public override async Task<DrzavaDeleteResponse> Handle([FromBody] DrzavaDeleteRequest request, CancellationToken cancellationToken)
		{
			var zapis = db.Drzava.Where(x => x.Naziv.ToLower() == request.Naziv.ToLower()).FirstOrDefault();

			if (zapis == null)
			{
				throw new Exception("Nije pronadjena drzava sa nazivom " + request.Naziv);
			}
			db.Remove(zapis);
			await db.SaveChangesAsync(cancellationToken: cancellationToken);

			return new DrzavaDeleteResponse
			{

			};


		}

	}
}
