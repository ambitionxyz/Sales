using PolicySearchService.Api.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicySearchService.Api.Queries
{
    public class FindPolicyResult
    {
        public List<PolicyDto> Policies { get; set; }
    }
}
