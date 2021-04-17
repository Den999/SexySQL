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
            
            currencyData.Date = new DateTime(1970,1,1,0,0,0,0);
            currencyData.Date = currencyData.Date.AddSeconds(int.Parse((string)jToken.SelectToken("timestamp") ?? "0"));
            currencyData.Dollar = (double) rates?.SelectToken("USD");
            currencyData.Euro = (double) rates?.SelectToken("EUR");
            currencyData.Jena = (double) rates?.SelectToken("JPY");
            
            return currencyData;
        }
    }
}