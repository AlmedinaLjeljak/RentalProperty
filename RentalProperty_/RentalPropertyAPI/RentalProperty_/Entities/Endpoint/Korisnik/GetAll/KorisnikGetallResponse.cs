namespace RentalProperty_.Entities.Endpoint.Korisnik.GetAll
{
	public class KorisnikGetallResponse
	{
		public List<KorisnikGetAllResponseRow> Korisnici { get; set; }
	}
	public class KorisnikGetAllResponseRow
	{
		public int Id { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Username { get; set; }
		public string Password { get; set; } 
		public string? Slika { get; set; }
		public string BrojTelefona { get; set; }
		public string NazivGrada { get; set; } 
		public string NazivSpol { get; set; }
		public string NazivDrzave { get; set; }
		public int GradId { get; set; }
		public int DrzavaId { get; set; }
		public int SpolId { get; set; }

	}
}
