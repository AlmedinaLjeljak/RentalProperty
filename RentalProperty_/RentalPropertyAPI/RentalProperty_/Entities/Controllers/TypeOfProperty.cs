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
	public class TypeOfPropertyController : ControllerBase
	{
		private readonly DataContext _dbContext;

		public TypeOfPropertyController(DataContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<ActionResult<TypeOfProperty>> GetAllTypesOfProperty()
		{
			
			var typesOfProperty = await _dbContext.TypeOfProperties.ToListAsync();
			return Ok(typesOfProperty);
		}

	
		[HttpPost]
		public async Task<ActionResult<TypeOfProperty>> AddTypeOfProperty(TypeOfProperty typeOfProperty)
		{
			
			_dbContext.TypeOfProperties.Add(typeOfProperty);
			await _dbContext.SaveChangesAsync();

			
			return CreatedAtAction(nameof(GetAllTypesOfProperty), new { id = typeOfProperty.Id }, typeOfProperty);
		}
	}
}
