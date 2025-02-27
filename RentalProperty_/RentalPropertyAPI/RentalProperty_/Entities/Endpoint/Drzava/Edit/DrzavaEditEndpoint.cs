using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Endpoint.Grad.Edit;
using RentalProperty_.Helper.Auth;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Drzava.Edit
{
	[Microsoft.AspNetCore.Mvc.Route("Drzava-Edit")]
	[MyAuthorization]
	public class DrzavaEditEndpoint : MyBaseEndpoint<DrzavaEditRequest, int>
	{
		private readonly DataContext db;

		public DrzavaEditEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpPost]
		public override async Task<int> Handle([FromBody] DrzavaEditRequest request, CancellationToken cancellationToken)
		{
			Models.Drzava? drzava;
			if (request.ID == 0)
			{
				drzava = new Models.Drzava();
				db.Add(drzava);
			}
			else
			{
				drzava = db.Drzava.FirstOrDefault(s => s.ID == request.ID);
				if (drzava == null)
					throw new Exception("pogresan id");

			}
			drzava.Naziv = request.Naziv.RemoveTags();

			await db.SaveChangesAsync(cancellationToken);

			return drzava.ID;
		}
	}
}
