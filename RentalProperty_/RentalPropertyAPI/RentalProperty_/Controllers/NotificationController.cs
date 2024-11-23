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
	public class NotificationController : ControllerBase
	{
		private readonly DataContext _dbContext;

		public NotificationController(DataContext dataContext)
		{
			_dbContext = dataContext;
		}

	
		[HttpGet]
		public async Task<ActionResult<Notification>> GetAllNotifications()
		{
			
			var notifications = await _dbContext.Notifications.ToListAsync();
			return Ok(notifications);
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Notification>> GetNotificationById(int id)
		{ 
			var notification = await _dbContext.Notifications.FirstOrDefaultAsync(n => n.NotificationID == id);

			if (notification == null)
				return NotFound($"Notification with ID {id} not found.");

			return Ok(notification);
		}
	}
}
