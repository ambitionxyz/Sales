using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyService.Api.Commands
{
    public class TerminatePolicyCommand : IRequest<TerminatePolicyResult>
    {
        public string PolicyNumber { get; set; }
        public DateTime TerminationDate { get; set; }
    }
}
