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
	public class OverheadCostController : ControllerBase
	{
		private readonly DataContext _dbContext;

		public OverheadCostController(DataContext dataContext)
		{
			_dbContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<OverheadCost>> GetAllOverheadCosts()
		{
	
			var overheadCosts = await _dbContext.OverheadCosts.ToListAsync();
			return Ok(overheadCosts);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OverheadCost>> GetOverheadCostById(int id)
		{
		
			var overheadCost = await _dbContext.OverheadCosts.FirstOrDefaultAsync(o => o.Id == id);

			if (overheadCost == null)
				return NotFound($"Overhead cost with ID {id} not found.");

			return Ok(overheadCost);
		}
	}
}
