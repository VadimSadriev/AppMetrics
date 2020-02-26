using System;

namespace AppMetrics.Infrastructure.Contracts
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CustomerResponse Customer { get; set; }
    }
}
