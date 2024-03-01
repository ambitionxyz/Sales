using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardService.Api.Queries.Dtos
{
    public class PeriodSaleDto
    {
        public DateTime PeriodDate { get; set; }

        public string Period { get; set; }

        public SalesDto Sales { get; set; }
    }
}
