using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._3.Consumidor
{
    class Program
    {
        private const string Url = @"http://localhost:5000/api/values";

        private static async Task<T> RetrieveAsync<T>(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            var serializer = JsonSerializer.CreateDefault();
            
            return serializer.Deserialize<T>(new JsonTextReader(new StringReader(content)));
        }

        static async Task Main(string[] args)
        {
            var url = args.FirstOrDefault() ?? Url;

            Console.WriteLine(url);

            var values = await RetrieveAsync<string[]>(url);

            foreach (var value in values)
                Console.WriteLine(value);

            Console.ReadKey();
        }
    }
}
