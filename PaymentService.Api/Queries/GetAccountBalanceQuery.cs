using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.Queries
{
    public class GetAccountBalanceQuery : IRequest<GetAccountBalanceQueryResult>
    {
        public string PolicyNumber { get; set; }
    }
}
