namespace RentalProperty_.Entities.Endpoint.Korisnik.Add
{
	public class KorisnikAddRequest
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string? Slika { get; set; }
		public string BrojTelefona { get; set; }
		public int GradID { get; set; }
		public int SpolId { get; set; }
		public int DrzavaId { get; set; }
	}
}
