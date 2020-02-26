using AppMetrics.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppMetrics.Application.Customers
{
    public interface ICustomerService
    {
        Task<ICollection<CustomerResponse>> GetAll();

        Task<CustomerResponse> GetById(Guid id);

        Task<Guid> Create(CustomerCreateRequest customerCreateRequest);
    }
}
