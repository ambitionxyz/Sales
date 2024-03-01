using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.Exceptions
{
    public class BussinesExceptions :Exception
    {
        public BussinesExceptions(string message) :
       base(message)
        {
        }

        public BussinesExceptions(string message, Exception ex) :
            base(message, ex)
        {
        }
    }
}
