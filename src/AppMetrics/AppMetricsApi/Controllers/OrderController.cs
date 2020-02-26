using AppMetrics.Application.Orders;
using AppMetrics.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppMetricsApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
           => Ok(await _orderService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
            => Ok(await _orderService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]OrderCreateRequest customerCreateRequest)
        {
            var orderId = await _orderService.Create(customerCreateRequest);

            return Ok(await _orderService.GetById(orderId));
        }
    }
}
