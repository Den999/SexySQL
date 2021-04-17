using System.IO;
using System.Net;
using System.Threading.Tasks;


namespace SexySQL
{
    public class SiteRequester
    {
        private const string Link =
            "http://api.exchangeratesapi.io/v1/latest?access_key=7b952c894419b83114c5ddb67c6b757e&format=1";
        public async Task<string> Run()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Link);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            
            using(HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using(Stream stream = response.GetResponseStream())
                
            using(StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}