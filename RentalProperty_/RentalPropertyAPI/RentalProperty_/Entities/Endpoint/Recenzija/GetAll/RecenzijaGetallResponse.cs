namespace RentalProperty_.Entities.Endpoint.Recenzija.GetAll
{
	public class RecenzijaGetallResponse
	{
		public List<RecenzijaGetallResponseRow> Recenzije { get; set; }
	}

	public class RecenzijaGetallResponseRow
	{
		public int Id { get; set; }
		public string Ime { get; set; } 
		public string Prezime { get; set; } 
		public string Tekst { get; set; }
		public string? Slika { get; set; }
	}
}


