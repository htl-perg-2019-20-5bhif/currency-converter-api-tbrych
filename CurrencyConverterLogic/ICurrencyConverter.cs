using System.Collections.Generic;

namespace CurrencyConverterLogic
{
    public interface ICurrencyConverter
    {
        public decimal CalculatePrice(string product, string targetCurrency, IEnumerable<Product> products, IEnumerable<Exchange> exchanges);
    }
}
