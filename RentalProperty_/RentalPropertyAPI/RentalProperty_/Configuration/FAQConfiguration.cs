using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Entities.Models;

namespace RentalProperty_.Configuration
{
	public class FAQConfiguration:IEntityTypeConfiguration<FAQ>
	{
		public void Configure(EntityTypeBuilder<FAQ> builder)
		{
			builder.HasData(
				new FAQ
				{
					Id = 1,
					Pitanje = "Koja je cijena izdavanja nekretnina?",
					Odgovor = "Cijena zavisi od lokacije i vaseg izbora sta zelite iznajmiti"
				},
				new FAQ
				{
					Id=2,
					Pitanje="Da li imate agente koji nam mogu pokazati nekretnine",
					Odgovor="Naravno, nudimo vam na raspolaganje sve agente"
				},
				new FAQ
				{
					Id=3,
					Pitanje="Od cega zavisi cijena nekretnine",
					Odgovor="Cijena zavisi od kvadrature zeljene nekretnine"
				},
				new FAQ
				{
					Id=4,
					Pitanje="Da li je moguce naznacenu nekretninu i kupiti a ne samo iznajmiti",
					Odgovor="Na svakoj nekrentini je naznaceno da li je nekretninu moguce samo iznajmiti ili cak i kupiti"

				}

				);
		}
	}
}
