using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyService.Api.Queries.Dto;

namespace PolicyService.Api.Queries
{
    public class GetPolicyDetailsQueryResult
    {
        public PolicyDetailsDto Policy { get; set; }
    }
}
