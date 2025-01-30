using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Authentification.TwoFOtkljucaj
{
	public class AutentifikacijaTwoFOtkljucajEndpoint:MyBaseEndpoint<AutentifikacijaTwoFOtkljucajRequest,NoResponse>
	{
		private readonly DataContext _applicationDbContext;
		private readonly MyAuthService _authService;

		private AutentifikacijaTwoFOtkljucajEndpoint(DataContext applicationDbContext,MyAuthService authService)
		{
			_applicationDbContext = applicationDbContext;
			_authService = authService;
		}
		[HttpPost("2f-otkljucaj")]
		public override async Task<NoResponse> Handle([FromBody]AutentifikacijaTwoFOtkljucajRequest request,CancellationToken cancellationToken)
		{
			if(!_authService.GetAuthInfo().isLogiran)
			{
				throw new Exception("Niste logirani");
			}
			var token = _authService.GetAuthInfo().autentifikacijaToken;
			if (token is null)
				throw new ArgumentNullException(nameof(token));
			if(request.Kljuc==token.TwoFKey)
			{
				token.IsOtkljucano = true;
				await _applicationDbContext.SaveChangesAsync(cancellationToken);
			}
			return new NoResponse();
		}

	}
}
