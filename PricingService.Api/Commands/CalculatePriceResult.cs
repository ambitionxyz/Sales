using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingService.Api.Commands
{
    public class CalculatePriceResult
    {
        public decimal TotalPrice { get; set; }
        public Dictionary<string, decimal> CoverPrices { get; set; }

        public static CalculatePriceResult Empty()
        {
            return new CalculatePriceResult { TotalPrice = 0M, CoverPrices = new Dictionary<string, decimal>() };
        }
    }
}
