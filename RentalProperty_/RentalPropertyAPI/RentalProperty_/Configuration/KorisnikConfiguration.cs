using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Entities.Models;

namespace RentalProperty_.Configuration
{
	public class KorisnikConfiguration:IEntityTypeConfiguration<Korisnik>
	{
		public void Configure(EntityTypeBuilder<Korisnik> builder)
		{
			builder.HasData(
				new Korisnik
				{
					ID = 3,
					Ime = "Almedina",
					Prezime = "Ljeljak",
					Username = "almedinalj",
					Password = "almedina123",
					BrojTelefona = "062123123",
					SpolID = 1,
					GradID = 5,
					DrazavaID = 1,
					Slika = "assets/1korisnik.jpg",
					is2FActive = true

				},
				new Korisnik
				{
					ID=4,
					Ime="Alema",
					Prezime="Duvnjak",
					Username="alemad",
					Password="alema123",
					BrojTelefona="062345678",
					SpolID=1,
					GradID=8,
					DrazavaID=1,
					Slika="assets/2korisnik.jpg",
					is2FActive=true
				},
				new Korisnik
				{
					ID=5,
					Ime="Adil",
					Prezime="Joldic",
					Username="adilj",
					Password="adil123",
					BrojTelefona="062897855",
					SpolID=2,
					GradID=3,
					DrazavaID=2,
					Slika="assets/3korisnik.jpg",
					is2FActive=true

				},
				new Korisnik
				{
					ID=6,
					Ime="Denis",
					Prezime="Music",
					Username="denism",
					Password="denis123",
					BrojTelefona="061789635",
					SpolID=2,
					GradID=4,
					DrazavaID=3,
					Slika="assets/4korisnik.jpg",
					is2FActive=true
				}
				);
		}

	}
}
