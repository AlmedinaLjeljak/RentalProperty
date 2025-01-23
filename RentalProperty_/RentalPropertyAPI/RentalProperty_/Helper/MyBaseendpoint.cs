using Microsoft.AspNetCore.Mvc;

namespace RentalProperty_.Helper
{
	[ApiController]

	public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
	{
		public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}
