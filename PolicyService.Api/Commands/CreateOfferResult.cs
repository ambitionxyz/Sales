using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyService.Api.Commands
{
    public class CreateOfferResult
    {
        public string OfferNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public Dictionary<string,decimal> CoversPrices { get; set; }

        public static CreateOfferResult Empty()
        {
            return new CreateOfferResult { CoversPrices = new Dictionary<string, decimal>() };

        }
    }
}
