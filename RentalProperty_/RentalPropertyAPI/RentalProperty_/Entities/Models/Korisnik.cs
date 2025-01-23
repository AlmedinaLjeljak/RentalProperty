using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Entities.Models
{
	[Table("Korisnik")]
	public class Korisnik:KorisnickiNalog
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string? Slika { get; set; }
		public string BrojTelefona { get; set; }
		[ForeignKey(nameof(Grad))]
		public int GradID { get; set; }
		public Grad Grad { get; set; }

		[ForeignKey(nameof(Spol))]
		public int SpolID { get; set; }
		public Spol Spol { get; set; }
		[ForeignKey(nameof(Drzava))]
		public int DrazavaID { get; set; }
		public Drzava Drzava { get; set; }
	}
}
