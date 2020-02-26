using App.Metrics;
using AppMetrics.Application.Customers;
using AppMetrics.Infrastructure.Contracts;
using AppMetrics.Infrastructure.Metrics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppMetricsApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMetrics _metrics;

        public CustomerController(ICustomerService customerService, IMetrics metrics)
        {
            _customerService = customerService;
            _metrics = metrics;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _customerService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
            => Ok(await _customerService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CustomerCreateRequest customerCreateRequest)
        {
            var customerId = await _customerService.Create(customerCreateRequest);
            _metrics.Measure.Counter.Increment(MetricsRegistry.CreatedCustomersCounter);

            return Ok(await _customerService.GetById(customerId));
        }
    }
}
