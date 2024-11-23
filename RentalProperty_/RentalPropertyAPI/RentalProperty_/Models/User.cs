using System.ComponentModel.DataAnnotations.Schema;

namespace RentalProperty_.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
	    public List<Gender> Genders { get; set; }
		public List<RentalProperty> RentalProperties { get; set; }
		
	
	}
}
