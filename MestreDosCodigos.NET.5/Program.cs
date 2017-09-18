using System;
using System.Collections.Generic;
using System.Linq;

namespace MestreDosCodigos.NET._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicializar enumerable");

            var generateEnumerable = GenerateEnumerable(7);

            Console.WriteLine("Inicializar lista");
            var generateListed = GenerateListed(7);

            Console.WriteLine("Enumerar enumerable");
            generateEnumerable.Count();

            Console.ReadKey();
        }

        static IEnumerable<int> GenerateEnumerable(int lenght)
        {
            var random = new Random();

            for (var i = 0; i < lenght; ++i)
            {
                var temp = random.Next();

                Console.WriteLine(temp);

                yield return temp;
            }
        }

        static IEnumerable<int> GenerateListed(int lenght)
        {
            var random = new Random();
            var list = new List<int>();

            for (var i = 0; i < lenght; ++i)
            {
                var temp = random.Next();

                Console.WriteLine(temp);

                list.Add(temp);
            }

            return list;
        }
    }
}
