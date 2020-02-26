using App.Metrics;
using App.Metrics.Counter;

namespace AppMetrics.Infrastructure.Metrics
{
    public class MetricsRegistry
    {
        public static CounterOptions CreatedCustomersCounter => new CounterOptions
        {
            Name = "Created Customers",
            Context = "CustomersApi",
            MeasurementUnit = Unit.Calls
        };

        public static CounterOptions CalledGetAllCustomers => new CounterOptions
        {
            Name = "Created db calls for all customers",
            Context = "Database",
            MeasurementUnit = Unit.Calls
        };
    }
}
