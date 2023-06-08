namespace WebApi.Filters;

using Microsoft.AspNetCore.Mvc.Filters;

public class MyActionFilter : IActionFilter
{
	public void OnActionExecuted(ActionExecutedContext context)
		=> Console.WriteLine($"OnActionExecuted: {context.HttpContext.TraceIdentifier}");

	public void OnActionExecuting(ActionExecutingContext context)
		=> Console.WriteLine($"OnActionExecuting: {context.HttpContext.TraceIdentifier}");
}
