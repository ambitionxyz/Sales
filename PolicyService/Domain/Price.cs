using System.Collections.ObjectModel;

namespace PolicyService.Domain
{
    public class Price
    {
        private readonly Dictionary<string, decimal> _coverPrices;

        public Price(Dictionary<string, decimal> coverPrices)
        {
            _coverPrices = coverPrices;
        }

        public IReadOnlyDictionary<string,decimal > CoverPrices => new ReadOnlyDictionary<string, decimal>(_coverPrices);
    }
}
