using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.Queries.Dtos
{
    public class PolicyAccountBalanceDto
    {
        public string PolicyAccountNumber { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
