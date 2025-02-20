namespace RentalProperty_.Entities.Endpoint.Spol.GetAll
{
	public class SpolGetAllResponse
	{
		public List<SpolGetAllResponseRow>Spolovi { get; set; }
	}
	public class SpolGetAllResponseRow
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
	}
}
