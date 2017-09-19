using System.Collections.Generic;

namespace MestreDosCodigos.NET._9
{
    public static class ClasseEstatica
    {
        static ClasseEstatica()
        {
            Valores = new[]
            {
                2m,
                3.7m,
                9.3m
            };
        }

        public static IEnumerable<decimal> Valores { get; }

        public static decimal Calclular(decimal valorA, decimal valorB) =>
            valorA + valorB;
    }
}
