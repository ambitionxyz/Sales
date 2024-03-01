using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyService.Api.Commands
{
    public class TerminatePolicyResult
    {
        public string PolicyNumber { get; set; }
        public decimal MoneyToReturn { get; set; }
    }
}
