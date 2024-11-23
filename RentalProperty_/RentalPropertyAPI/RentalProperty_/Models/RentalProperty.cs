using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class RentalProperty
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double SquaresMeters { get; set; }
		public string Adress { get; set; }
		public bool isRented { get; set; }
		public DateTime? RentalStart { get; set; }
		public DateTime? RentalEnd { get; set; }
		public bool isDeleted { get; set; }
		public List<OverheadCost> Costs { get; set; }
		public List<TypeOfProperty> Types { get; set; }
		public List<Review> Reviews { get; set; }
	
		public User User { get; set; }
		public Country Country { get; set; }	
		public Person Person { get; set; }
		
	}
}
