using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Entities.Models
{
	public class Nekretnina
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public float Cijena { get; set; }
		public string Opis { get; set; }
		public string ? Slika { get; set; }
		[ForeignKey(nameof(Kategorija))]
		public int KategorijaID { get; set; }
		public Kategorija Kategorija { get; set; }
	}
}
