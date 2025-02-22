using System.Collections.Generic;

using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using RentalProperty_.Entities.Models;
using RentalProperty_.Configuration;

namespace RentalProperty_.Data
{
    public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.NoAction;
			}



			modelBuilder.Entity<KorisnikAgent>().HasKey(x => new { x.KorisnikId, x.AgentId, x.DatumTermina });

			modelBuilder.Entity<KorisnikNekretnina>().HasKey(x => new { x.NekretninaId, x.KorisnikId, x.datumIzdavanja });






			modelBuilder.ApplyConfiguration(new GradConfiguration());
			modelBuilder.ApplyConfiguration(new DrzavaConfiguration());
			modelBuilder.ApplyConfiguration(new AdministratorConfiguration());
			modelBuilder.ApplyConfiguration(new FAQConfiguration());
			modelBuilder.ApplyConfiguration(new KorisnikConfiguration());
			modelBuilder.ApplyConfiguration(new SpolConfiguration());
		}

		public DbSet<Administrator> Administrator { get; set; }
		public DbSet<Agent> Agent { get; set; }
		public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
		public DbSet<Drzava> Drzava { get; set; }
		public DbSet<FAQ> FAQ { get; set; }
		public DbSet<Grad> Grad { get; set; }
		public DbSet<Kategorija> Kategorija { get; set; }
		public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
		public DbSet<Korisnik> Korisnik { get; set; }
		public DbSet<KorisnikAgent> KorisnikAgent { get; set; }
		public DbSet<KorisnikNekretnina> KorisnikNekretnina { get; set; }
		public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemu { get; set; }
		public DbSet<Nekretnina> Nekretnina { get; set; }
		public DbSet<Recenzija> Recenzija { get; set; }
		public DbSet<Spol> Spol { get; set; }
		public DbSet<Tfa> Tfa { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);


		}

		




	}

}




