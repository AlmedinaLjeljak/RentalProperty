using RentalProperty_.Models;
using System.Collections.Generic;

using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace RentalProperty_.Data
{
	public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<RentalProperty> RentalProperties { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<OverheadCost> OverheadCosts { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<TypeOfProperty> TypeOfProperties { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);


		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);
		
		
		}




	}

}




