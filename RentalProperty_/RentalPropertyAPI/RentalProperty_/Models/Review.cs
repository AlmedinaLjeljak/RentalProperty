using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class Review
	{
		public int ReviewId { get; set; }
		public string? Content { get; set; }
		public DateTime? Date { get; set; }
		
		public RentalProperty RentalProperty { get; set; }

		
	
		
	}
}
