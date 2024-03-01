using DashboardService.Api.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardService.Api.Queries
{
    public class GetTotalSalesResult
    {
        public SalesDto Total { get; set; }

        public Dictionary<string, SalesDto> PerProductTotal { get; set; }
    }
}
