using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RentalProperty_.Entities.Models
{
	[Table("KorisnickiNalog")]
	public abstract class KorisnickiNalog
	{
		[Key]
		public int ID { get; set; }
		public string Username { get; set; }
		[JsonIgnore]
		public string Password { get; set; }

		[JsonIgnore]
		public Korisnik? Korisnik => this as Korisnik;

		[JsonIgnore]
		public Administrator? Administrator => this as Administrator;

		public bool isAdministrator => Administrator != null;
		public bool isKorisnik => Korisnik != null;

		public bool is2FActive { get; set; }


	}
}
