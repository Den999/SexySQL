using System;

namespace SexySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Database();
            var item = new CurrencyData
            {
                Date = DateTime.Now,
                Dollar = 81.3,
                Euro = 90.2,
                Jena = 0.71,
            };
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.f"));
            db.InsertCurrencyData(item);
        }
    }
}