using DashboardService.Api.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardService.Api.Queries
{
    public class GetAgentsSalesResult
    {
        public IDictionary<string, SalesDto> PerAgentTotal { get; set; }
    }
}
