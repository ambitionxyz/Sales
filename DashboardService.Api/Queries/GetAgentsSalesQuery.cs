using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardService.Api.Queries
{
    public class GetAgentsSalesQuery : IRequest<GetAgentsSalesResult>
    {
        public string AgentLogin { get; set; }
        public string ProductCode { get; set; }
        public DateTime SalesDateFrom { get; set; }
        public DateTime SalesDateTo { get; set; }
    }
}
