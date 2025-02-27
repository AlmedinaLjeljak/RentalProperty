namespace RentalProperty_.Entities.Endpoint.Drzava.GetAll
{
	public class DrzavaGetAllResponse
	{
		public List<DrzavaGetAllResponseRow> Drzave { get; set; }
	}
	public class DrzavaGetAllResponseRow
	{
		public int ID { get; set; }
		public string Naziv { get; set; }
	}
}
