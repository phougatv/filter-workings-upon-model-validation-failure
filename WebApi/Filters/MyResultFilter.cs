namespace WebApi.Filters;

using Microsoft.AspNetCore.Mvc.Filters;

public class MyResultFilter : IResultFilter
{
	public void OnResultExecuted(ResultExecutedContext context)
		=> Console.WriteLine($"OnResultExecuted: {context.HttpContext.TraceIdentifier}");

	public void OnResultExecuting(ResultExecutingContext context)
	{
		Console.WriteLine($"OnResultExecuting: {context.HttpContext.TraceIdentifier}");
		if (context.ModelState.IsValid) return;
		Console.WriteLine($"No. of model validation failures: {context.ModelState.Count}");
	}
}
