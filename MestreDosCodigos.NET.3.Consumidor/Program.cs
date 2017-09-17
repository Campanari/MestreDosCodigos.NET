using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._3.Consumidor
{
    class Program
    {
        private static readonly string Url = @"http://localhost:54115/api/values";

        private static async Task<T> RetrieveAsync<T>(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            var serializer = JsonSerializer.CreateDefault();
            
            return serializer.Deserialize<T>(new JsonTextReader(new StringReader(content)));
        }

        static void Main(string[] args)
        {
            var url = Url;

            Console.WriteLine(url);

            var values = RetrieveAsync<string[]>(url)
                .GetAwaiter()
                .GetResult();

            foreach (var value in values)
                Console.WriteLine(value);

            Console.ReadKey();
        }
    }
}
