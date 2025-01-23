using RentalProperty_.Data;
using RentalProperty_.Entities.Models;
using System.Text.Json.Serialization;

namespace RentalProperty_.Helper.Auth
{
	public class MyAuthService
	{
		private readonly DataContext _applicationDbContext;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public MyAuthService(DataContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
		{
			_applicationDbContext = applicationDbContext;
			_httpContextAccessor = httpContextAccessor;
		}
		public bool JelLogiran()
		{
			return GetAuthInfo().isLogiran;
		}

		public bool isAdmin()
		{
			return GetAuthInfo().korisnickiNalog?.isAdministrator ?? false;
		}

		public bool isKorisnik()
		{
			return GetAuthInfo().korisnickiNalog?.isKorisnik ?? false;
		}


		public MyAuthInfo GetAuthInfo()
		{
			string? authToken = _httpContextAccessor.HttpContext!.Request.Headers["my-auth-token"];

			AutentifikacijaToken? autentifikacijaToken = _applicationDbContext.AutentifikacijaToken
				.Include(x => x.korisnickiNalog)
				.SingleOrDefault(x => x.vrijednost == authToken);

			return new MyAuthInfo(autentifikacijaToken);
		}
	}

	public class MyAuthInfo
	{
		public MyAuthInfo(AutentifikacijaToken? autentifikacijaToken)
		{
			this.autentifikacijaToken = autentifikacijaToken;
		}

		[JsonIgnore]
		public KorisnickiNalog? korisnickiNalog => autentifikacijaToken?.korisnickiNalog;
		public AutentifikacijaToken? autentifikacijaToken { get; set; }

		public bool isLogiran => korisnickiNalog != null;

	}
}
