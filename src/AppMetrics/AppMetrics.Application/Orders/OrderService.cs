using AppMetrics.DAL;
using AppMetrics.DAL.Entities;
using AppMetrics.Infrastructure.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMetrics.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrderService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Create(OrderCreateRequest orderCreateRequest)
        {
            var order = new Order
            {
                Name = orderCreateRequest.Name
            };

            try
            {
                await _context.Orders.AddAsync(order);

                await _context.SaveChangesAsync();

                return order.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred during order creation", ex);
            }
        }

        public async Task<ICollection<OrderResponse>> GetAll()
        {
            var orders = await _context.Orders
                .Include(x => x.Customer)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<ICollection<OrderResponse>>(orders);
        }

        public async Task<OrderResponse> GetById(Guid id)
        {
            var order = await GetByIdInternal(id);

            return _mapper.Map<OrderResponse>(order);
        }

        private async Task<Order> GetByIdInternal(Guid id)
        {
            return await _context.Orders
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception($"Order with id: {id} not found");
        }
    }
}
