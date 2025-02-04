namespace RentalProperty_.Entities.Endpoint.Grad.Search
{
	public class GradSearchResponse
	{
		public List<GradSearchResponseDodatak> Gradovi { get; set; }
	}
	public class GradSearchResponseDodatak
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
	}
}
