using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RentalProperty_.Services;

namespace RentalProperty_.Helper.Auth
{
	public class MyAuthorizationAttribute : TypeFilterAttribute
	{
		public MyAuthorizationAttribute() : base(typeof(MyAuthorizationAsyncActionFilter))
		{
		}
	}
	public class MyAuthorizationAsyncActionFilter : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(
			ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var authService = context.HttpContext.RequestServices.GetService<MyAuthService>()!;
			var actionLogService = context.HttpContext.RequestServices.GetService<MyActionLogService>()!;

			if (!authService.JelLogiran())
			{
				context.Result = new UnauthorizedObjectResult("Niste logirani na sistem!");
				return;
			}

			MyAuthInfo myAuthInfo = authService.GetAuthInfo();

			if (authService.GetAuthInfo().korisnickiNalog.is2FActive
				&& !myAuthInfo.autentifikacijaToken.IsOtkljucano)
			{
				context.Result = new UnauthorizedObjectResult("Niste otključali 2F!");
				return;
			}

			await next();
			await actionLogService.Create(context.HttpContext);



		}
	}
}
