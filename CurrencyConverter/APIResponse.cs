namespace CurrencyConverter
{
    public class APIResponse
    {
        public decimal Price { get; }

        public APIResponse(decimal price)
        {
            Price = price;
        }
    }
}
