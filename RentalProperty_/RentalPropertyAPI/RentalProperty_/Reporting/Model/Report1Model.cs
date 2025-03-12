namespace RentalProperty_.Reporting.Model
{
	public class Report1Model
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Username { get; set; }
		public string NazivGrad { get; set; }
		public string NazivSpol { get; set; }
		public string NazivDrzave { get; set; }

		public static List<Report1Model> Get()
		{
			return new List<Report1Model> { };
		}
	}
}
