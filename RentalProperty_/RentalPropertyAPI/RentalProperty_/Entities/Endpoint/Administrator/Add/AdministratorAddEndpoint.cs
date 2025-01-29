using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;
using System.Runtime.CompilerServices;

namespace RentalProperty_.Entities.Endpoint.Administrator.Add
{
	[Microsoft.AspNetCore.Mvc.Route("Administrator-Add")]
	public class AdministratorAddEndpoint:MyBaseEndpoint<AdministratorAddRequest,AdministratorAddResponse>
	{
		private readonly DataContext db;
		private readonly MyAuthService auth;
		public AdministratorAddEndpoint(DataContext db,MyAuthService auth)
		{
			this.db = db;
			this.auth = auth;
		}
		[HttpPost]
		public async override Task<AdministratorAddResponse> Handle([FromBody]AdministratorAddRequest request,CancellationToken cancellationToken)
		{
			var novi = new Entities.Models.Administrator
			{
				Ime = request.Ime,
				Prezime = request.Prezime,
				Username = request.Username,
				Password = request.Password

			};
			db.Administrator.Add(novi);
			await db.SaveChangesAsync(cancellationToken: cancellationToken);
			return new AdministratorAddResponse
			{
				ID = novi.ID,
				Ime = novi.Ime,
				Prezime = novi.Prezime
			};
		}
	}
}
