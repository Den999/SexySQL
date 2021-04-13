using System;
using System.Threading.Tasks;

namespace SexySQL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(await new SiteRequester().Run());
        }
    }
}