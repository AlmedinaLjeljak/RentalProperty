namespace RentalProperty_.Entities.Endpoint.Administrator.Add
{
	public class AdministratorAddRequest
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int ID { get; internal set; }
	}
}
