using System;
using System.Collections.Generic;
using System.Text;

namespace AppMetrics.Infrastructure.Contracts
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<OrderResponse> Orders { get; set; }
    }
}
