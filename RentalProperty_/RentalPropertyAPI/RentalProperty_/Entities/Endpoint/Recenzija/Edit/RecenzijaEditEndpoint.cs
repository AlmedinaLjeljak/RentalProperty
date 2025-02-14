using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Recenzija.Edit
{
	[Microsoft.AspNetCore.Mvc.Route("Recenzija-Edit")]
	[MyAuthorization]
	public class RecenzijaEditEndpoint:MyBaseEndpoint<RecenzijaEditRequest,int>
	{
		private readonly DataContext db;
		public RecenzijaEditEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpPost]
		public override async Task<int> Handle([FromBody]RecenzijaEditRequest request,CancellationToken cancellationToken)
		{
			Models.Recenzija? recenzija;
			if(request.Id==0)
			{
				recenzija = new Models.Recenzija();
				db.Add(recenzija);
			}
			else
			{
				recenzija = db.Recenzija.FirstOrDefault(s => s.Id == request.Id);
				if (recenzija == null)
					throw new Exception("pogresan id");
			}

			recenzija.Ime = request.Ime.RemoveTags();
			recenzija.Prezime = request.Prezime.RemoveTags();
			recenzija.Tekst = request.Tekst.RemoveTags();
			recenzija.Slika = request.Slika?.RemoveTags();


			await db.SaveChangesAsync(cancellationToken);

			return request.Id;
		}
	}
}
