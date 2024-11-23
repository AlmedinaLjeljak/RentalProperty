using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class Gender
	{
		public int Id { get; set; }
		public string Name { get; set; }
	
		public User User { get; set; }

		
	}
}
