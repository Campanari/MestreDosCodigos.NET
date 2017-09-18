using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now} Início");

            Task.WaitAll(
                DownloadAsync(ProfileUrl),
                DownloadAsync(RepositoriesUrl));

            Console.WriteLine($"{DateTime.Now} Fim");

            Console.ReadKey();
        }

        private const string ProfileUrl = "https://api.github.com/users/Campanari";
        private const string RepositoriesUrl = "https://api.github.com/users/Campanari/repos";

        private static async Task<string> DownloadAsync(string url)
        {
            await Task.Delay(new Random().Next(3000));

            Console.WriteLine($"{DateTime.Now} Início - {url}");

            var client = new HttpClient();

            var response = await client.GetAsync(url);

            var @return = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{DateTime.Now} Fim - {url}");

            return @return;
        }
    }
}
