﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalProperty_.Entities.Models
{
	public class LogKretanjePoSistemu
	{
		[Key]
		public int ID { get; set; }
		[ForeignKey(nameof(Korisnik))]
		public int KorisnikID { get; set; }
		public KorisnickiNalog Korisnik { get; set; }
		public string? QueryPath { get; set; }
		public string? PostData { get; set; }
		public DateTime Vrijeme { get; set; }
		public string? IpAdresa { get; set; }
		public string? ExceptionMessage { get; set; }
		public bool IsException { get; set; }
	}
}
