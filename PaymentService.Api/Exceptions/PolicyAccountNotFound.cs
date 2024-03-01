using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.Exceptions
{
    public class PolicyAccountNotFound : BussinesExceptions
    {
        public PolicyAccountNotFound(string accountNumber) :
        base($"Policy Account not found. Looking for account with number: {accountNumber}")
        {
        }
    }
}
