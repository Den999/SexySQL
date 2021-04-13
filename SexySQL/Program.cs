using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SexySQL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            JToken data = JObject.Parse(await new SiteRequester().Run());
            CurrencyData currencyData = CurrencyDataParser.Parse(data);
            
            Console.WriteLine(currencyData.Date);
            Console.WriteLine(currencyData.Euro);
            Console.WriteLine(currencyData.Dollar);
            Console.WriteLine(currencyData.Jena);
        }
    }
}