using CurrencyConverterLogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly HttpClient client;
        private readonly ICSVParser parser;
        private readonly ICurrencyConverter converter;

        public CurrencyConverterController(IHttpClientFactory factory, ICSVParser parser, ICurrencyConverter converter)
        {
            client = factory.CreateClient("currencyAPI");
            this.parser = parser;
            this.converter = converter;
        }

        [HttpGet]
        [Route("{product}/price")]
        public async Task<IActionResult> Get(string product, [FromQuery]string targetCurrency)
        {
            var responseRates = await client.GetAsync("ExchangeRates.csv");
            responseRates.EnsureSuccessStatusCode();
            var responseProduct = await client.GetAsync("Prices.csv");
            responseProduct.EnsureSuccessStatusCode();

            var ratesString = await responseRates.Content.ReadAsStringAsync();
            var productsString = await responseProduct.Content.ReadAsStringAsync();

            IEnumerable<Product> products = parser.ParseProducts(productsString);
            IEnumerable<Exchange> exchanges = parser.ParseExchange(ratesString);

            decimal price = converter.CalculatePrice(product, targetCurrency, products, exchanges);
            return Ok(new APIResponse(price));
        }
    }
}
