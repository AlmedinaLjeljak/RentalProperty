using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Helper;
using RentalProperty_.Models; // Zameni sa stvarnim imenom namespace-a za model
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalProperty_.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class RentalPropertyController : ControllerBase
	{
		private readonly DataContext _dbContext;

		public RentalPropertyController(DataContext dbContext)
		{
			_dbContext = dbContext;
		}

		
		[HttpGet]
		public async Task<ActionResult<PagedList<RentalProperty>>> GetAllRentalProperties(string search = null, int pageNumber = 1, int itemsPerPage = 10)
		{
			
			var query = _dbContext.RentalProperties.AsQueryable();

			if (!string.IsNullOrEmpty(search))
			{
				query = query.Where(rp => rp.Name.Contains(search));
			}

		
			var pagedList = PagedList<RentalProperty>.Create(query, pageNumber, itemsPerPage);

			return Ok(pagedList);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<RentalProperty>> GetRentalPropertyById(int id)
		{
			var property = await _dbContext.RentalProperties.FirstOrDefaultAsync(p => p.Id == id);

			if (property == null)
				return NotFound($"Rental Property with ID {id} not found.");

			return Ok(property);
		}

		
		[HttpPost]
		public async Task<ActionResult<RentalProperty>> AddRentalProperty(RentalProperty property)
		{
			
			_dbContext.RentalProperties.Add(property);
			await _dbContext.SaveChangesAsync();

			
			return CreatedAtAction(nameof(GetRentalPropertyById), new { id = property.Id }, property);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRentalProperty(int id)
		{
			
			var property = await _dbContext.RentalProperties.FirstOrDefaultAsync(p => p.Id == id);

			if (property == null)
				return NotFound($"Rental Property with ID {id} not found.");

			
			_dbContext.RentalProperties.Remove(property);
			await _dbContext.SaveChangesAsync();

			return NoContent();
		}
	}
}
