namespace RentalProperty_.Entities.Models
{
	public class KorisnikNekretnina
	{
		public int KorisnikId { get; set; }
		public Korisnik Korisnik { get; set; }
		public int NekretninaId { get; set; }
		public Nekretnina Nekretnina { get; set; }
		public DateTime datumIzdavanja { get; set; }
		public bool Izdano { get; set; }
	}
}
