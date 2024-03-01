using PaymentService.Api.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.Queries
{
    public class GetAccountBalanceQueryResult
    {
        public PolicyAccountBalanceDto Balance { get; set; }
    }
}
