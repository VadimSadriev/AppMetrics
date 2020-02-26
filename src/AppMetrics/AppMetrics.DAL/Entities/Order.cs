using System;
using System.Collections.Generic;
using System.Text;

namespace AppMetrics.DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
