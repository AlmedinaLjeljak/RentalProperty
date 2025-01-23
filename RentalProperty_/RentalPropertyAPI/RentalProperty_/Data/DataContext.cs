using System.Collections.Generic;

using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using RentalProperty_.Entities.Models;

namespace RentalProperty_.Data
{
    public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<Administrator> Administrators { get; set; }
		public DbSet<Agent> Agents { get; set; }
		public DbSet<AutentifikacijaToken> AutentifikacijaTokens { get; set; }
		public DbSet<Drzava> Drzavas { get; set; }
		public DbSet<FAQ> FAQs { get; set; }
		public DbSet<Grad> Grads { get; set; }
		public DbSet<Kategorija> Kategorijas { get; set; }
		public DbSet<KorisnickiNalog> KorisnickiNalogs { get; set; }
		public DbSet<Korisnik> Korisniks { get; set; }
		public DbSet<KorisnikAgent> KorisnikAgents { get; set; }
		public DbSet<KorisnikNekretnina> KorisnikNekretninas { get; set; }
		public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemus { get; set; }
		public DbSet<Nekretnina> Nekretninas { get; set; }
		public DbSet<Recenzija> Recenzijas { get; set; }
		public DbSet<Spol> Spols { get; set; }
		public DbSet<Tfa> Tfas { get; set; }



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




