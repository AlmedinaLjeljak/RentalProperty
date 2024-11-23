using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class OverheadCost
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Amount { get; set; }
		public string Currency { get; set; }
		public DateTime? Date { get; set; }
		
		public RentalProperty RentalProperty { get; set; }
		
	
		

	}
}
