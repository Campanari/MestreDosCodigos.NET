using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._3.Consumidor
{
    class Program
    {
        private const string Url = @"http://localhost:54115/api/values";

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
            Console.WriteLine(Url);

            var values = await RetrieveAsync<string[]>(Url);

            foreach (var value in values)
                Console.WriteLine(value);

            Console.ReadKey();
        }
    }
}
