using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Entities.Models;

namespace RentalProperty_.Configuration
{
	public class AdministratorConfiguration:IEntityTypeConfiguration<Administrator>
	{
		public void Configure(EntityTypeBuilder<Administrator> builder)
		{
			builder.HasData(
				new Administrator
				{
					ID = 1,
					Ime = "Almedina",
					Prezime = "Ljeljak",
					Username = "admin",
					Password = "admin",
					is2FActive = false
				},
				new Administrator
				{
					ID = 2,
					Ime = "Alema",
					Prezime = "Duvnjak",
					Username = "host",
					Password = "host",
					is2FActive = false
				}

				);
		}
	}
}
