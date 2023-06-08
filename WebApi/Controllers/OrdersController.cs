namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApi.ValidationAttributes;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
	private readonly List<Ordering> _orders;

	public OrdersController()
	{
		_orders = GetOrders();
	}

	[HttpGet("{id}")]
	public IActionResult GetById([GreaterThanZeroIntegerValidation] Int32 id)
	{
		var order = _orders.FirstOrDefault(o => o.Id == id);
		if (order is null)
			return NotFound($"Order not found for id: {id}.");
		return Ok(order);
	}

	private static List<Ordering> GetOrders()
	{
		var orders = new List<Ordering>(4)
		{
			new Ordering
			{
				Id = 1,
				ProductIdQuantityMap = new Dictionary<Int32, Int32>{ {1, 2} }
			},
			new Ordering
			{
				Id = 2,
				ProductIdQuantityMap = new Dictionary<Int32, Int32>{ {1, 4} }
			},
			new Ordering
			{
				Id = 3,
				ProductIdQuantityMap = new Dictionary<Int32, Int32>{ {2, 3} }
			},
			new Ordering
			{
				Id = 4,
				ProductIdQuantityMap = new Dictionary<Int32, Int32>{ {3, 6} }
			}
		};

		return orders;
	}
}

public class Ordering
{
	public Int32 Id { get; set; }

	public IDictionary<Int32, Int32> ProductIdQuantityMap { get; set; } = null!;
}
