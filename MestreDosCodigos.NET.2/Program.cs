using System;
using System.Reflection;
using static System.Console;

namespace MestreDosCodigos.NET._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var objetos = new Classe[]
            {
                new Classe1
                {
                    Atributo1 = nameof(Classe1.Atributo1),
                    Atributo2 = int.MinValue,
                    Atributo3 = decimal.MaxValue,
                    Atributo4 = ulong.MinValue,
                    Atributo5 = nameof(Classe1.Atributo5).ToCharArray(),
                    Atributo6 = false,
                    Atributo7 = Guid.NewGuid()
                },
                new Classe2
                {
                    Atributo1 = uint.MaxValue,
                    Atributo2 = short.MaxValue,
                    Atributo3 = double.MinValue,
                    Atributo4 = float.MinValue,
                    Atributo5 = nameof(Classe2.Atributo5),
                    Atributo6 = 'C',
                    Atributo7 = true
                }
            };
            
            foreach (var objeto in objetos)
                ExibirInformacoes(objeto);

            ReadKey();
        }

        private static void ExibirInformacoes(object objeto)
        {
            var tipo1 = objeto.GetType();

            WriteLine(tipo1.FullName);

            var propriedades1 = tipo1.GetProperties();

            foreach (var propriedade in propriedades1)
            {
                var value = propriedade.GetValue(objeto);

                WriteLine($"{propriedade.Name} = {value}");
            }

            WriteLine();
        }
    }
}