using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Data;

namespace RentalProperty_.Entities.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class NekretninaController:ControllerBase
	{
		private readonly DataContext db;
		public NekretninaController(DataContext dbContext)
		{
			db = dbContext;
		}
	}
}
