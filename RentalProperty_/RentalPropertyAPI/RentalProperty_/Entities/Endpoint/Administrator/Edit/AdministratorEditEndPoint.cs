using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Administrator.Edit
{
	[Microsoft.AspNetCore.Mvc.Route("Administrator-Edit")]
	public class AdministratorEditEndPoint:MyBaseEndpoint<AdministratorEditRequest,int>
	{
		private readonly DataContext db;
		public AdministratorEditEndPoint(DataContext db)
		{
			this.db = db;
		}
		[HttpPost]
		public override async Task<int> Handle([FromBody]AdministratorEditRequest request,CancellationToken cancellationToken)
		{
			Models.Administrator? administrator;
			if(request.ID==0)
			{
				administrator = new Models.Administrator();
				db.Add(administrator);
			}
			else
			{
				administrator = db.Administrator.FirstOrDefault(s => s.ID == request.ID);
				if (administrator == null)
					throw new Exception("ID je pogresan");
			}
			administrator.Ime = request.Ime.RemoveTags();
			administrator.Prezime = request.Prezime.RemoveTags();
			administrator.Username = request.Username.RemoveTags();
			administrator.Password = request.Password.RemoveTags();


			await db.SaveChangesAsync(cancellationToken);

			return administrator.ID;

		}

	}
	

	
}
