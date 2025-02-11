using Microsoft.AspNetCore.Hosting.Server;

namespace RentalProperty_.Entities.Endpoint.Korisnik.Edit
{
	public class KorisniciEditRequest
	{
		public int Id { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string? Slika { get; set; }
		public string BrojTelefona { get; set; }
		public int GradId { get; set; }
		public int SpolId { get; set; }
		public int DrzavaId { get; set; }
	}
}
