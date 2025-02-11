namespace RentalProperty_.Entities.Endpoint.Korisnik.GetById
{
	public class KorisnikGetByIDResponse
	{
		public int KorisnikId { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Username { get; set; }
		public string? Slika { get; set; }
		public string BrojTelefona { get; set; }
		public string NazivGrada { get; set; }
		public string NazivSpola { get; set; }
		public string NazivDrzave { get; set; }
	}
}
