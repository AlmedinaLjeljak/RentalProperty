namespace RentalProperty_.Entities.Models
{
	public class KorisnikAgent
	{
		public int KorisnikId { get; set; }
		public Korisnik Korisnik { get; set; }
		public int AgentId { get; set; }
		public Agent Agent { get; set; }
		public DateTime DatumTermina { get; set; }
		public int VrijemeSat { get; set; }
	}
}
