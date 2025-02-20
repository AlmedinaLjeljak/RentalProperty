namespace RentalProperty_.Entities.Endpoint.Tfa.GetAll
{
	public class TfaGetAllResponse
	{
		public List<TfaGetallResponseRow> Tfas { get; set; }
	}
	public class TfaGetallResponseRow
	{
		public int Id { get; set; }
		public string TwoKey { get; set; }
	}
}
