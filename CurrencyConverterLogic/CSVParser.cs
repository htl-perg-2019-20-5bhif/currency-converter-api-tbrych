using System.Collections.Generic;
using System.Globalization;

namespace CurrencyConverterLogic
{
    public class CSVParser : ICSVParser
    {
        public IEnumerable<Product> ParseProducts(string content)
        {
            List<string[]> elements = ParseToLines(content);
            List<Product> products = new List<Product>();

            foreach (var curProduct in elements)
            {
                products.Add(new Product(curProduct[0], curProduct[1], decimal.Parse(curProduct[2], CultureInfo.InvariantCulture)));
            }

            return products;
        }

        public IEnumerable<Exchange> ParseExchange(string content)
        {
            List<string[]> elements = ParseToLines(content);
            List<Exchange> exchanges = new List<Exchange>();

            foreach (var curElement in elements)
            {
                exchanges.Add(new Exchange(curElement[0], decimal.Parse(curElement[1], CultureInfo.InvariantCulture)));
            }

            return exchanges;
        }

        public List<string[]> ParseToLines(string content)
        {
            List<string[]> elements = new List<string[]>();

            string[] lines = content.Replace("\r", string.Empty).Split("\n");
            bool first = true;
            foreach (var line in lines)
            {
                if (!first)
                {
                    string[] curElements = line.Split(",");
                    if (curElements.Length > 1)
                        elements.Add(curElements);
                }
                first = false;
            }

            return elements;
        }
    }
}
