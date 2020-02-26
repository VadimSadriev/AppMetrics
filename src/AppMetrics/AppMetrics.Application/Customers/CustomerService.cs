using App.Metrics;
using AppMetrics.DAL;
using AppMetrics.DAL.Entities;
using AppMetrics.Infrastructure.Contracts;
using AppMetrics.Infrastructure.Metrics;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppMetrics.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMetrics _metrics;

        public CustomerService(DataContext context, IMapper mapper, IMetrics metrics)
        {
            _context = context;
            _mapper = mapper;
            _metrics = metrics;
        }

        public async Task<Guid> Create(CustomerCreateRequest customerCreateRequest)
        {
            var customer = new Customer
            {
                Name = customerCreateRequest.Name
            };

            try
            {
                await _context.Customers.AddAsync(customer);

                await _context.SaveChangesAsync();

                return customer.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred during customer creation", ex);
            }
        }

        public async Task<ICollection<CustomerResponse>> GetAll()
        {
            var customers = await _context.Customers
                .Include(x => x.Orders)
                .AsNoTracking()
                .ToArrayAsync();

            _metrics.Measure.Counter.Increment(MetricsRegistry.CalledGetAllCustomers);

            return _mapper.Map<ICollection<CustomerResponse>>(customers);
        }

        public async Task<CustomerResponse> GetById(Guid id)
        {
            var customer = await GetByIdInternal(id);

            return _mapper.Map<CustomerResponse>(customer);
        }

        private async Task<Customer> GetByIdInternal(Guid id)
        {
            return await _context.Customers
                .Include(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new Exception($"Customer with id : {id} not found");
        }
    }
}
