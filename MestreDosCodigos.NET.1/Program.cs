using System;
using static System.Console;

namespace MestreDosCodigos.NET._1
{
    class Program
    {
        static void Main(string[] args)
        {
            short @short = 1;
            byte @byte = 1;
            int @int = 1;
            uint @uint = 1u;
            long @long = 1L;
            ulong @ulong = 1uL;
            float @float = 1f;
            double @double = 1.0;
            decimal @decimal = 1m;

            // Cast implícito
            // Nenhuma sintaxe especial é necessária, pois é uma conversão segura.
            // Em todos os casos abaixo objeto destino é capaz de armazenar qualquer valor do objeto de origem.
            @int = @short;
            @int = @byte;
            @uint = @byte;
            @long = @short;
            @long = @int;
            @long = @byte;
            @long = @uint;
            @ulong = @byte;
            @ulong = @uint;
            @float = @short;
            @float = @byte;
            @float = @int;
            @float = @uint;
            @float = @long;
            @float = @ulong;
            @double = @short;
            @double = @byte;
            @double = @int;
            @double = @uint;
            @double = @long;
            @double = @ulong;
            @double = @float;
            @decimal = @short;
            @decimal = @byte;
            @decimal = @int;
            @decimal = @uint;
            @decimal = @long;
            @decimal = @ulong;

            // Cast explícito
            // ´´E necessa´´rio especificar o tipo de destino
            // Essas convers~~oes podem causar perda de precis~~ao ou valor e lançar exceç~~ao.
            @int = (int) @decimal;
            @long = (long) @double;
            @float = (float) @decimal;
            @ulong = (ulong) @int;
            @short = (short) @int;

            WriteLine("Hello World!");
        }
    }
}