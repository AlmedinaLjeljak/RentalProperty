using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Entities.Models;

namespace RentalProperty_.Configuration
{
	public class SpolConfiguration:IEntityTypeConfiguration<Spol>
	{
		public void Configure(EntityTypeBuilder<Spol> builder)
		{
			builder.HasData(
				new Spol
				{
					ID = 1,
					Naziv = "Zenski"
				},new Spol
				{
					ID=2,
					Naziv="Muski"
				});
		}
	}
}
