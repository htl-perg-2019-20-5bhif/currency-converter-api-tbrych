namespace CurrencyConverterLogic
{
    public class Product
    {
        public string Description { get; }
        public string Currency { get; }
        public decimal Price { get; }

        public Product(string desc, string currency, decimal price)
        {
            Description = desc;
            Currency = currency;
            Price = price;
        }
    }

    public class Exchange
    {
        public string Currency { get; }
        public decimal Rate { get; }

        public Exchange(string curreny, decimal rate)
        {
            Currency = curreny;
            Rate = rate;
        }
    }
}
