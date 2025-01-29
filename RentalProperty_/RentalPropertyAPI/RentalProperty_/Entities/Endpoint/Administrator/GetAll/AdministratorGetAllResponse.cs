namespace RentalProperty_.Entities.Endpoint.Administrator.GetAll
{
	public class AdministratorGetAllResponse
	{
		public List<AdministratorGetAllResponseRow> Administrator { get; set; }
	}
	public class AdministratorGetAllResponseRow
	{
		public int Id { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }


	}
}
