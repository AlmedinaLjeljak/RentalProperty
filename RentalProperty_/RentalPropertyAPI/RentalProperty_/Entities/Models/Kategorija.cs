using System.ComponentModel.DataAnnotations;

namespace RentalProperty_.Entities.Models
{
	public class Kategorija
	{
		[Key]
		public int ID { get; set; }
		public string Naziv { get; set; }
	}
}
