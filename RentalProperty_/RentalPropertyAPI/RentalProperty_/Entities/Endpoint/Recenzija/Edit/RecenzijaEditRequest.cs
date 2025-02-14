namespace RentalProperty_.Entities.Endpoint.Recenzija.Edit
{
	public class RecenzijaEditRequest
	{
		public int Id { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Tekst { get; set; }
		public string? Slika { get; set; }
	}
}
