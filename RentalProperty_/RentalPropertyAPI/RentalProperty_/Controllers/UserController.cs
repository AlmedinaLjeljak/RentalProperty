using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;
using RentalProperty_.Models; // Zameni sa stvarnim imenom namespace-a za model
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RentalProperty_.Helper;

namespace RentalProperty_.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly DataContext _dbContext;

		public UserController(DataContext dbContext)
		{
			_dbContext = dbContext;
		}

		
		[HttpGet]
		public async Task<ActionResult<PagedList<User>>> GetAllUsers(string name, int pageNumber = 1, int pageSize = 10)
		{
			
			var usersQuery = _dbContext.Users
				.Where(u => string.IsNullOrEmpty(name) || u.Name.Contains(name))
				.OrderBy(u => u.Name)
				.AsQueryable();

			var pagedUsers = PagedList<User>.Create(usersQuery, pageNumber, pageSize);
			return Ok(pagedUsers);
		}

		
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUserById(int id)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

			if (user == null)
				return NotFound($"User with ID {id} not found.");

			return Ok(user);
		}

		
		[HttpPost]
		public async Task<ActionResult<User>> AddUser(User user)
		{
			_dbContext.Users.Add(user);
			await _dbContext.SaveChangesAsync();

			return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
		}

		
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

			if (user == null)
				return NotFound($"User with ID {id} not found.");

			_dbContext.Users.Remove(user);
			await _dbContext.SaveChangesAsync();

			return NoContent(); 
		}
	}
}
