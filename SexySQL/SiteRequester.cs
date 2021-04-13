using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SexySQL
{
    public class SiteRequester
    {
        // public async Task Run()
        // {
        //     //string address = "http://139.28.223.173:5000/";
        //     //Console.WriteLine(student.Message);
        //     //var jsonStudent = JsonConvert.SerializeObject(student);
        //     using (var client = new HttpClient())
        //     {
        //         var body = new StringContent(jsonStudent, Encoding.UTF8, "application/json");
        //         var response = await (await client.PostAsync(postMessages, body)).Content.ReadAsStringAsync();
        //         Console.WriteLine(response);
        //     }
        // }
        
        public async Task<string> Run()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.exchangeratesapi.io/v1/latest?access_key=7b952c894419b83114c5ddb67c6b757e&format=1");
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.exchangeratesapi.io/v1/latest?access_key=7b952c894419b83114c5ddb67c6b757e&base=RUB&symbols=USD,JPY,EUR");

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