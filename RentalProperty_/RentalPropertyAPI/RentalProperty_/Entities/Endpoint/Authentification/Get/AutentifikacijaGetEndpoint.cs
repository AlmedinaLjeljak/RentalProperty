using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Authentification.Get
{

	[Microsoft.AspNetCore.Mvc.Route("Autentifikacija")]
	public class AutentifikacijaGetEndpoint : MyBaseEndpoint<AutentifikacijaGetRequest, MyAuthInfo>
	{
		private readonly DataContext _applicationDbContext;
		private readonly MyAuthService _authService;
		public AutentifikacijaGetEndpoint(DataContext applicationDbContext, MyAuthService authService)
		{
			_applicationDbContext = applicationDbContext;
			_authService = authService;
		}

		[HttpPost("Get")]
		public override async Task<MyAuthInfo> Handle([FromBody] AutentifikacijaGetRequest request, CancellationToken cancellationToken)
		{
			AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

			return new MyAuthInfo(autentifikacijaToken);
		}
	}


}
