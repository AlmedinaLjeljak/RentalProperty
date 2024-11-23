using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class Notification
	{
		public int NotificationID { get; set; }
		public string? Name { get; set; }
		public string? Content { get; set; }
		public DateTime? Date { get; set; }
		
		public Person Person { get; set; }
		
		
		

	}
}
