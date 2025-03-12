using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Reporting.Model;
using System.Data;

namespace RentalProperty_.Reporting.Controller
{

	[ApiController]
	[Route("[controller]/[action]")]
	public class Report1Controller : ControllerBase
	{
		private DataContext _db;

		public Report1Controller(DataContext db)
		{
			_db = db;
		}

		public static List<Report1Model> GetKorisnici(DataContext db)
		{
			List<Report1Model> podaci = db.Korisnik
				.Include("Grad")
				.Include("Spol")
				//.Include("Drzava")
				.Select(s => new Report1Model
				{
					Ime = s.Ime,
					Prezime = s.Prezime,
					Username = s.Username,
					NazivGrad = s.Grad.Naziv,
					NazivSpol = s.Spol.Naziv,
					//NazivDrzave = s.Drzava.Naziv

				}).ToList();

			return podaci;
		}

		[HttpGet]
		[Route("PDFReport")]
		public IActionResult Index()
		{

			LocalReport _localReport = new LocalReport("Reporting/RDLC/Report1.rdlc");
			List<Report1Model> podaci = GetKorisnici(_db);
			DataSet ds = new DataSet();
			_localReport.AddDataSource("dsKorisnici", podaci);

			

			// PDF FORMAT

			ReportResult result = _localReport.Execute(RenderType.Pdf);
			return File(result.MainStream, "application/pdf");

		}


		[HttpGet]
		[Route("ExcelReport")]
		public IActionResult Index2()
		{

			LocalReport _localReport = new LocalReport("Reporting/RDLC/Report1.rdlc");
			List<Report1Model> podaci = GetKorisnici(_db);
			DataSet ds = new DataSet();
			_localReport.AddDataSource("dsKorisnici", podaci);

		

			// EXCEL FORMAT

			ReportResult result = _localReport.Execute(RenderType.ExcelOpenXml);
			return File(result.MainStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

			// PDF FORMAT

			//ReportResult result = _localReport.Execute(RenderType.Pdf);
			//return File(result.MainStream, "application/pdf");

		}
	}
}
