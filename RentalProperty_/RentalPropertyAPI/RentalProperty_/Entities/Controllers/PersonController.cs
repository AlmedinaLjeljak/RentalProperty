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
	public class PersonController : ControllerBase
	{
		private readonly DataContext _dbContext;

		public PersonController(DataContext dataContext)
		{
			_dbContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<Person>> GetAllPersons()
		{
			
			var persons = await _dbContext.Persons.ToListAsync();
			return Ok(persons);
		}

		
		[HttpGet("{id}")]
		public async Task<ActionResult<Person>> GetPersonById(int id)
		{
		
			var person = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == id);

			if (person == null)
				return NotFound($"Person with ID {id} not found.");

			return Ok(person);
		}
	}
}
