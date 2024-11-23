using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Contact { get; set; }
		public bool LegalEntity { get; set; }
		public bool IsDeleted { get; set; }
		public List<Notification> Notifications { get; set; }
		public List<RentalProperty> RentalProperties { get; set; }
		
	}
}
