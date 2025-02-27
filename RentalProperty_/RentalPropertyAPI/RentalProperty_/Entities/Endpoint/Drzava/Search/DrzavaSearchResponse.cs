namespace RentalProperty_.Entities.Endpoint.Drzava.Search
{
	public class DrzavaSearchResponse
	{
		public List<DrzavaSearchResponseDodatak> Drzave { get; set; }
	}
	public class DrzavaSearchResponseDodatak
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
	}
}
