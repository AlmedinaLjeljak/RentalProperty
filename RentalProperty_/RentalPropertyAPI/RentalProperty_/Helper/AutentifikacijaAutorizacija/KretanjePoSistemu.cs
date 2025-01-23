using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using RentalProperty_.Data;
using RentalProperty_.Entities.Models;

namespace RentalProperty_.Helper.AutentifikacijaAutorizacija
{
	public class KretanjePoSistemu
	{
		public static int Save(HttpContext httpContext, IExceptionHandlerPathFeature exceptionMessage = null)
		{
			KorisnickiNalog korisnik = httpContext.GetLoginInfo().korisnickiNalog;

			var request = httpContext.Request;

			var queryString = request.Query;

			if (queryString.Count == 0 && !request.HasFormContentType)
				return 0;

			//IHttpRequestFeature feature = request.HttpContext.Features.Get<IHttpRequestFeature>();
			string detalji = "";
			if (request.HasFormContentType)
			{
				foreach (string key in request.Form.Keys)
				{
					detalji += " | " + key + "=" + request.Form[key];
				}
			}

			var x = new LogKretanjePoSistemu
			{
				Korisnik = korisnik,
				Vrijeme = DateTime.Now,
				QueryPath = request.GetEncodedPathAndQuery(),
				PostData = detalji,
				IpAdresa = request.HttpContext.Connection.RemoteIpAddress?.ToString(),
			};

			if (exceptionMessage != null)
			{
				x.IsException = true;
				x.ExceptionMessage = exceptionMessage.Error.Message + " |" + exceptionMessage.Error.InnerException;
			}

			DataContext? db = httpContext.RequestServices.GetService<DataContext>();

			db.Add(x);
			db.SaveChanges();

			return x.ID;
		}




	}
}
