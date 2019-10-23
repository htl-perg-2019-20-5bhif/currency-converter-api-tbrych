using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverterLogic
{
    public class CurrencyConverter : ICurrencyConverter
    {
        public decimal CalculatePrice(string product, string targetCurrency, IEnumerable<Product> products, IEnumerable<Exchange> exchanges)
        {
            Product curProduct = products.Where(p => p.Description.Equals(product)).FirstOrDefault();

            if (targetCurrency.Equals(curProduct.Currency))
            {
                return Math.Round(curProduct.Price, 2);
            }

            decimal result = Math.Round(ConvertToEuro(curProduct.Price, curProduct.Currency, exchanges), 2);

            if (!targetCurrency.Equals("EUR"))
            {
                result = Math.Round(ConvertFromEuro(result, targetCurrency, exchanges), 2);
            }

            return result;
        }

        private decimal ConvertToEuro(decimal value, string curCurrency, IEnumerable<Exchange> exchanges)
        {
            decimal curFactor = exchanges.Where(e => e.Currency.Equals(curCurrency)).FirstOrDefault().Rate;

            return value / curFactor;
        }

        private decimal ConvertFromEuro(decimal value, string curCurrency, IEnumerable<Exchange> exchanges)
        {
            decimal curFactor = exchanges.Where(e => e.Currency.Equals(curCurrency)).FirstOrDefault().Rate;

            return value * curFactor;
        }
    }
}
