using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Entities.Models;

namespace RentalProperty_.Configuration
{
	public class GradConfiguration:IEntityTypeConfiguration<Grad>
	{
		public void Configure(EntityTypeBuilder<Grad> builder)
		{
			builder.HasData(
				new Grad
				{
					ID=1,
					Naziv="Mostar"

				},
				new Grad
				{
					ID=2,
					Naziv="Sarajevo"
				},
				new Grad
				{
					ID=3,
					Naziv="Zagreb"
				},
				new Grad
				{
					ID=4,
					Naziv="Beograd"
				},
				new Grad
				{
					ID=5,
					Naziv="Konjic"
				},
				new Grad
				{
					ID=6,
					Naziv="Tuzla"
				},
				new Grad
				{
					ID=7,
					Naziv="Zenica"
				},
				new Grad
				{
					ID=8,
					Naziv="Bugojno"
				},
				new Grad
				{
					ID=9,
					Naziv="Bihac"
				},
				new Grad
				{
					ID=10,
					Naziv="Banja Luka"
				}
				);
		}
	}
}
