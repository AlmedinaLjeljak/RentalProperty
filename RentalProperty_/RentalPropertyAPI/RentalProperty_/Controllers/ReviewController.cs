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
	public class ReviewController : ControllerBase
	{
		private readonly DataContext _dbContext;

		public ReviewController(DataContext dbContext)
		{
			_dbContext = dbContext;
		}

	
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
		{
			
			var reviews = await _dbContext.Reviews.ToListAsync();
			return Ok(reviews);
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Review>> GetReviewById(int id)
		{
			
			var review = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);

			if (review == null)
				return NotFound($"Review with ID {id} not found.");

			return Ok(review);
		}

	
		[HttpPost]
		public async Task<ActionResult<Review>> AddReview(Review review)
		{
			
			_dbContext.Reviews.Add(review);
			await _dbContext.SaveChangesAsync();

			
			return CreatedAtAction(nameof(GetReviewById), new { id = review.ReviewId }, review);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReview(int id)
		{
			var review = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);

			if (review == null)
				return NotFound($"Review with ID {id} not found.");

			
			_dbContext.Reviews.Remove(review);
			await _dbContext.SaveChangesAsync();

			
			return NoContent();
		}
	}
}