using System;

namespace MestreDosCodigos.NET._9
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var valor in ClasseEstatica.Valores)
                Console.WriteLine(valor);

            var valorCalculado = ClasseEstatica.Calclular(4m, 3.5m);

            Console.WriteLine(valorCalculado);

            Console.ReadKey();
        }
    }
}
