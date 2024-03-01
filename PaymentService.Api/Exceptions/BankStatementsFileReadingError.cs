using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.Exceptions
{
    public class BankStatementsFileReadingError : BussinesExceptions
    {
        public BankStatementsFileReadingError(Exception ex) :
            base("Policy Account not found. BankStatementsFileReadingError", ex)
        {
        }
    }
}
