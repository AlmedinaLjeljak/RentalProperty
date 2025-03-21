﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sql;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Authentification.Logout
{
	[Microsoft.AspNetCore.Mvc.Route("Autentifikacija")]
	public class AutentifikacijaLogoutEndpoint : MyBaseEndpoint<NoRequest, NoResponse>
	{

		private readonly DataContext _applicationDbContext;
		private readonly MyAuthService _authService;

		public AutentifikacijaLogoutEndpoint(DataContext applicationDbContext, MyAuthService authService)
		{
			_applicationDbContext = applicationDbContext;
			_authService = authService;
		}

		[HttpPost("Logout")]
		public override async Task<NoResponse> Handle([FromBody] NoRequest request, CancellationToken cancellationToken)
		{
			AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

			if (autentifikacijaToken == null)
				return new NoResponse();

			_applicationDbContext.Remove(autentifikacijaToken);
			await _applicationDbContext.SaveChangesAsync(cancellationToken);
			return new NoResponse();
		}

	}
}
