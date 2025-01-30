namespace RentalProperty_.Entities.Endpoint.FAQ.GetAll
{
	public class FAQGetAllResponse
	{
		public List<FAQGetAllResponseRow> FAQ { get; set; }
	}
	public class FAQGetAllResponseRow
	{
		public int ID { get; set; }
		public string Pitanje { get; set; }
		public string Odgovor { get; set; }
	}
}
