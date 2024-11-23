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
	public class CountryController:ControllerBase
	{
		private readonly DataContext _dbContext;
		public CountryController(DataContext dataContext)
		{
			this._dbContext = dataContext;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
		{
			
			var countries = await _dbContext.Countries.ToListAsync();

			
			return Ok(countries);
		}
	}
}
