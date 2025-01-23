using System.ComponentModel.DataAnnotations;

namespace RentalProperty_.Entities.Models
{
	public class Tfa
	{
		[Key]
		public int ID { get; set; }
		public string TwoFKey { get; set; }
	}
}
