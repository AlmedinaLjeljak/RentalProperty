using System.ComponentModel.DataAnnotations;

namespace RentalProperty_.Entities.Models
{
	public class Recenzija
	{
		[Key]
		public int Id { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Tekst { get; set; }
		public string ? Slika { get; set; }
	}
}
