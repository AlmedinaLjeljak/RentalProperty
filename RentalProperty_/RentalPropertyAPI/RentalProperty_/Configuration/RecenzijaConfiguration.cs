using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Entities.Models;

namespace RentalProperty_.Configuration
{
	public class RecenzijaConfiguration:IEntityTypeConfiguration<Recenzija>
	{
		public void Configure(EntityTypeBuilder<Recenzija> builder)
		{
			builder.HasData(
				new Recenzija
				{
					Id = 1,
					Ime = "Alema",
					Prezime = "Duvnjak",
					Tekst = "Dugo trazenu nekretninu pronasli smo pomocu ove agencije za izdavanje nekretnina. Zadovoljni korisnici. ",
					Slika = "assets/1rec.jpg"
				},
				new Recenzija
				{
					Id = 2,
					Ime = "Almedina",
					Prezime = "Ljeljak",
					Tekst = "Iznajmljivali smo nekreninu preko ove agencije dugi niz godina,prezadovoljni smo. ",
					Slika = "assets/2rec.jpg"

				},
				new Recenzija
				{
					Id = 3,
					Ime = "Emina",
					Prezime = "Junuz",
					Tekst = "Zadovoljni korisnici svih usluga koje nudi data agencija za iznajmljivanje.",
					Slika = "assets/3rec.jpg"
				},
				new Recenzija
				{
					Id = 4,
					Ime = "Iris",
					Prezime = "Memic",
					Tekst = "Usluga je na zadovoljavajucem nivou.",
					Slika = "assets/4rec.jpg"
				});
		}
	}
}
