using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Helper.Auth;

namespace RentalProperty_.Entities.Endpoint.Korisnik.GetById
{
	[Route("Korisnik-GetById")]
	public class KorisnikGetByIdEndpoint:MyBaseEndpoint<int,KorisnikGetByIDResponse>
	{
		private readonly DataContext _dataContext;
		private readonly MyAuthService _authService;

		public KorisnikGetByIdEndpoint(DataContext dataContext,MyAuthService authService)
		{
			_dataContext = dataContext;
			_authService = authService;
		}
		[HttpGet("{id}")]
		public override async Task<KorisnikGetByIDResponse> Handle(int id,CancellationToken cancellationToken)
		{
			var korisnik = await _dataContext.Korisnik.FindAsync(id);

			var gradovi = _dataContext.Grad.ToList();
			var spolovi = _dataContext.Spol.ToList();
			var drzave = _dataContext.Drzava.ToList();

			if (korisnik is null)
				throw new Exception("Nije pronadjen korisnik sa ovim id " + id);

			var grad = gradovi[korisnik.GradID - 1];
			var spol = spolovi[korisnik.SpolID - 1];
			var drzava = drzave[korisnik.DrazavaID - 1];
			var result = new KorisnikGetByIDResponse
			{
				KorisnikId = korisnik.ID,
				Ime=korisnik.Ime,
				Prezime=korisnik.Prezime,
				BrojTelefona=korisnik.BrojTelefona,
				Slika=korisnik.Slika,
				Username=korisnik.Username,
				NazivGrada=grad.Naziv,
				NazivSpola=korisnik.Spol.Naziv,
				NazivDrzave=korisnik.Drzava.Naziv

			};
			return result;
		
		}
	}
}
