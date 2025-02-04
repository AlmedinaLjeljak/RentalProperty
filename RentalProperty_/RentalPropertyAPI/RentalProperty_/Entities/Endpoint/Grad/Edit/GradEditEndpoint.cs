using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Grad.Edit
{
	[Microsoft.AspNetCore.Mvc.Route("Grad-Edit")]
	[MyAuthorization]
	public class GradEditEndpoint:MyBaseEndpoint<GradEditRequest,int>
	{
		private readonly DataContext db;
		
		public GradEditEndpoint(DataContext db)
		{
			this.db = db;
		}

		[HttpPost]
		public override async Task<int> Handle([FromBody]GradEditRequest request,CancellationToken cancellationToken)
		{
			Models.Grad? grad;
			if(request.ID==0)
			{
				grad = new Models.Grad();
				db.Add(grad);
			}
			else
			{
				grad = db.Grad.FirstOrDefault(s => s.ID == request.ID);
				if (grad == null)
					throw new Exception("pogresan id");

			}
			grad.Naziv = request.Naziv.RemoveTags();

			await db.SaveChangesAsync(cancellationToken);

			return grad.ID;
		}
	}
}
