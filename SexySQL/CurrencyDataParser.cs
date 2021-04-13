using System;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;

namespace SexySQL
{
    public static class CurrencyDataParser
    {
        public static CurrencyData Parse(JToken jToken)
        {
            var currencyData = new CurrencyData();
            JToken rates = jToken.SelectToken("rates");

            currencyData.Date = DateTime.Parse((string) jToken.SelectToken("date") ?? string.Empty);
            currencyData.Dollar = (double) rates?.SelectToken("USD");
            currencyData.Euro = (double) rates?.SelectToken("EUR");
            currencyData.Jena = (double) rates?.SelectToken("JPY");

            return currencyData;
        }
    }
}