using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSphere.Services;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(int userId)
        {
            var order = await _service.CreateOrderAsync(userId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var order = await _service.GetOrdersAsync();
            return Ok(order);
        }
    }
}
