namespace RentalProperty_.Entities.ViewModels
{
	public class DrzavaGetVM
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string Opis => Id + " " + Naziv;
	}
}
