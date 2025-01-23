using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalProperty_.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class GenderController : ControllerBase
	{
		private readonly DataContext _dbContext;

		public GenderController(DataContext dataContext)
		{
			_dbContext = dataContext;
		}

		// GET: /Gender
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Gender>>> GetAllGenders()
		{
			
			var genders = await _dbContext.Genders.ToListAsync();
			return Ok(genders);
		}

		// GET: /Gender/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Gender>> GetGenderById(int id)
		{
		
			var gender = await _dbContext.Genders.FirstOrDefaultAsync(g => g.Id == id);

			if (gender == null)
				return NotFound($"Gender with ID {id} not found.");

			return Ok(gender);
		}
	}
}
