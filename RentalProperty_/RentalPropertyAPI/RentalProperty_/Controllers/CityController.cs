using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Models;

namespace RentalProperty_.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class CityController:ControllerBase
	{
		private readonly DataContext _dbContext;
		public CityController(DataContext dataContext)
		{
			this._dbContext = dataContext;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
		{
			
			var cities = await _dbContext.Cities.ToListAsync();

		
			return Ok(cities);
		}
	}
}
