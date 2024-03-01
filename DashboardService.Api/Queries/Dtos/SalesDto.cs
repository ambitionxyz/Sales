using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardService.Api.Queries.Dtos
{
    public class SalesDto
    {
        public SalesDto()
        {
        }

        public SalesDto(long policiesCount, decimal premiumAmount)
        {
            PoliciesCount = policiesCount;
            PremiumAmount = premiumAmount;
        }

        public long PoliciesCount { get; set; }
        public decimal PremiumAmount { get; set; }
    }
}
