using System.Collections.Generic;

namespace CurrencyConverterLogic
{
    public interface ICSVParser
    {
        public IEnumerable<Product> ParseProducts(string content);

        public IEnumerable<Exchange> ParseExchange(string content);
    }
}
