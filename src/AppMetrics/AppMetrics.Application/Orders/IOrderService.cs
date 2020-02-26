using AppMetrics.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppMetrics.Application.Orders
{
    public interface IOrderService
    {
        Task<ICollection<OrderResponse>> GetAll();

        Task<OrderResponse> GetById(Guid id);

        Task<Guid> Create(OrderCreateRequest orderCreateRequest);
    }
}
