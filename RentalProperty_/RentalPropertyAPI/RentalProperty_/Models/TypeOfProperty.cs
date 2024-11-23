using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class TypeOfProperty
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public RentalProperty RentalProperty { get; set; }
 
		
	

	}
}
