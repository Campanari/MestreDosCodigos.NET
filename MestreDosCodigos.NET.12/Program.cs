using System;
using System.Collections.Generic;

namespace MestreDosCodigos.NET._12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Invariante - Permite somente a atribução do mesmo tipo!");
            IInvariant<object> invariant = new Invariant<object>();

            Console.WriteLine("Covariante - Permite a atribução do mesmo tipo e tipo derivado!");
            ICovariant<object> covariant = new Covariant<string>();

            Console.WriteLine("Contravariante - Permite a atribução do mesmo tipo e tipo base!");
            IContravariant<string> contravariant = new Contravariant<object>();
        }

        class Invariant<T> : IInvariant<T>
        {
            
        }

        interface IInvariant<T>
        {
            
        }

        class Covariant<T> : ICovariant<T>
        {
            
        }

        interface ICovariant<out T>
        {

        }

        class Contravariant<T> : IContravariant<T>
        {
            
        }

        interface IContravariant<in T>
        {

        }
    }
}
