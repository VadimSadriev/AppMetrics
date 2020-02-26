using System.Collections.Generic;

namespace AppMetrics.Infrastructure.Contracts
{
    public class ExceptionContract
    {
        public List<ExceptionErrorContract> Errors { get; set; }
    }
}
