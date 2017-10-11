using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MestreDosCodigos.NET._7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now} Início");
            
            var tasks = new List<Task>();

            var pastas = await RetrieveAsync<Content[]>(ContentUrl);

            foreach (var pasta in pastas.Where(p => "dir".Equals(p.Type, StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.WriteLine(pasta.Name);

                var livros = await RetrieveAsync<Content[]>(pasta.Url);

                tasks.AddRange(livros
                    .Where(livro => "file".Equals(livro.Type, StringComparison.InvariantCultureIgnoreCase))
                    .Select(livro => DownloadAsync(
                        livro.Name, livro.DownloadUrl,
                        Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"{DateTime.Now} Fim");

            Console.ReadKey();
        }

        private const string ContentUrl = "https://api.github.com/repos/miguellgt/books/contents";

        private static async Task DownloadAsync(string name, string url, string path)
        {
            Console.WriteLine($"{DateTime.Now} Início - {url}");
            
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            var bytes = await response.Content.ReadAsByteArrayAsync();

            await File.WriteAllBytesAsync(Path.Combine(path, name), bytes);

            Console.WriteLine($"{DateTime.Now} Fim - {url}");
        }

        private static async Task<T> RetrieveAsync<T>(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent
                .Add(new ProductInfoHeaderValue("MestreDosCodigos.NET", "1.0"));

            var response = await client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            var serializer = JsonSerializer.CreateDefault();
            serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return serializer.Deserialize<T>(new JsonTextReader(new StringReader(content)));
        }

        [JsonObject]
        public class Content
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("url")]
            public string Url { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("download_url")]
            public string DownloadUrl { get; set; }
        }
    }
}
