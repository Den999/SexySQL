using System;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SexySQL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            JToken data = JObject.Parse(await new SiteRequester().Run());
            Console.WriteLine(data.ToString());
            CurrencyData currencyData = CurrencyDataParser.Parse(data);

            Console.WriteLine(currencyData.Date);
            Console.WriteLine(currencyData.Euro);
            Console.WriteLine(currencyData.Dollar);
            Console.WriteLine(currencyData.Jena);
            var db = new Database();
            /*var item = new CurrencyData
            {
                Date = DateTime.Now,
                Dollar = 81.3,
                Euro = 90.2,
                Jena = 0.71,
            };*/
            Console.WriteLine(currencyData.Date.ToString("yyyy-MM-dd"));
            await db.InsertCurrencyData(currencyData);
        }
    }
}