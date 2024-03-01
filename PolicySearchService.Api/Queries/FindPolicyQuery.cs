using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicySearchService.Api.Queries
{
    public class FindPolicyQuery : IRequest<FindPolicyResult>
    {
        public string QueryText { get; set; }
    }
}
