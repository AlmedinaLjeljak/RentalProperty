namespace RentalProperty_.Entities.Endpoint.Grad.GetAll
{
	public class GradGetAllResponse
	{
		public List<GradGetAllResponseRow>Gradovi { get; set; }
		
	}
	public class GradGetAllResponseRow
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
	}
}
