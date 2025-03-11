using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;

namespace RentalProperty_.Entities.Endpoint.Administrator.GetAll
{
	[Microsoft.AspNetCore.Mvc.Route("Administrator-GetAll")]
	public class AdministratorGetAllEndpoint:MyBaseEndpoint<AdministratorGetAllRequest,AdministratorGetAllResponse>
	{
		private readonly DataContext db;
		public AdministratorGetAllEndpoint(DataContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public override async Task<AdministratorGetAllResponse> Handle([FromQuery]AdministratorGetAllRequest request,CancellationToken cancellationToken)
		{
			var administrator = await db.Administrator
				.Select(x => new AdministratorGetAllResponseRow
				{
					Id = x.ID,
					Username = x.Username,
					Password = x.Password,
					Ime = x.Ime,
					Prezime = x.Prezime

				}).ToListAsync(cancellationToken: cancellationToken);
			return new AdministratorGetAllResponse
			{
				Administrator = administrator
			};
		}
	}
}
