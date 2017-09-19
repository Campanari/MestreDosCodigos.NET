using System;
using System.IO;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._10
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var path = Path.GetTempPath();
            var watcher = new FileSystemWatcher(path)
            {
                EnableRaisingEvents = true
            };

            watcher.Changed += (sender, e) => Console.WriteLine($"{DateTime.Now} Changed - Name: {e.Name}");
            watcher.Created += (sender, e) => Console.WriteLine($"{DateTime.Now} Created - Name: {e.Name}");
            watcher.Deleted += (sender, e) => Console.WriteLine($"{DateTime.Now} Deleted - Name: {e.Name}");
            watcher.Renamed += (sender, e) => Console.WriteLine($"{DateTime.Now} Renamed - Old: {e.OldName} New: {e.Name}");
            watcher.Error += (sender, e) => Console.WriteLine($"{DateTime.Now} {e.GetException().Message}");

            await GerarEventosAsync();

            Console.ReadKey();

            watcher.Dispose();
        }

        public static async Task GerarEventosAsync()
        {
            var fileName = Path.GetTempFileName();
            
            var file = File.Create(fileName);

            using (var streamWriter = new StreamWriter(file))
            {
                await streamWriter.WriteLineAsync("Linha 0");
                await streamWriter.WriteLineAsync("Linha 1");
                await streamWriter.WriteLineAsync("Linha 2");
                await streamWriter.WriteLineAsync("Linha 3");
                await streamWriter.WriteLineAsync("Linha 4");
                await streamWriter.WriteLineAsync("Linha 5");
                await streamWriter.WriteLineAsync("Linha 6");
                await streamWriter.WriteLineAsync("Linha 7");
                await streamWriter.WriteLineAsync("Linha 8");
                await streamWriter.WriteLineAsync("Linha 9");
            }
            
            file.Close();

            var newFileName = fileName.Replace(Path.GetExtension(fileName), ".txt");

            File.Move(fileName, newFileName);
            
            File.Delete(newFileName);
        }
    }
}
