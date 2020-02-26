using AppMetrics.Application.Customers;
using AppMetrics.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppMetricsApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
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

            return Ok(await _customerService.GetById(customerId));
        }
    }
}
