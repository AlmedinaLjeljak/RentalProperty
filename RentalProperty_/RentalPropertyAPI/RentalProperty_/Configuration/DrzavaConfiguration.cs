using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Entities.Models;

namespace RentalProperty_.Configuration
{
	public class DrzavaConfiguration:IEntityTypeConfiguration<Drzava>
	{
		public void Configure(EntityTypeBuilder<Drzava> builder)
		{
			builder.HasData(
				new Drzava
				{
					ID = 1,
					Naziv = "Bosna i Hercegovina"
				},
				new Drzava
				{
					ID=2,
					Naziv="Hrvatska"
				},
				new Drzava
				{
					ID=3,
					Naziv="Srbija"
				});
		}
	}
}
