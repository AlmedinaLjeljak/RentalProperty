using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
		
		public Country Country { get; set; }
		



	}
}
