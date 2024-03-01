using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyService.Api.Queries
{
    public class GetPolicyDetailsQuery : IRequest<GetPolicyDetailsQueryResult>
    {
        public string PolicyNumber {  get; set; }
    }
}
