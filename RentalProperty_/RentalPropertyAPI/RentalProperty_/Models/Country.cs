using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class Country
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<City> Cities { get; set; }
		public List<RentalProperty> RentalProperties { get; set; }

	}
}
