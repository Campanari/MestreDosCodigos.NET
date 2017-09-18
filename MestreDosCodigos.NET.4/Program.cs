using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var csharp6 =  new CSharp6();

            Console.WriteLine(csharp6.ReadOnlyAutoProperty);

            Console.WriteLine(csharp6.AutoPropertyInitializers);

            Console.WriteLine(csharp6.ExpressionBodiedMemberReadOnlyProperty);

            Console.WriteLine(csharp6.UsingStatic);

            Console.WriteLine(csharp6.NullConditionalOperators);

            Console.WriteLine(csharp6.StringInterpolation);
            Console.WriteLine(csharp6.StringInterpolationSpecificCulture);

            csharp6.ExceptionFilters();

            Console.WriteLine(csharp6.NameOfExpression);

            csharp6.AwaitInCatchAndFinallyBlocks();

            csharp6.IndexInitializerList.ForEach(Console.WriteLine);
            foreach (var keyValuePair in csharp6.IndexInitializerDictionary)
                Console.WriteLine(keyValuePair);

            var extensionMethodsForCollectionInitializers = new Queue<int>
            {
                1,
                2,
                3
            };

            while (extensionMethodsForCollectionInitializers.Any())
            {
                var value = extensionMethodsForCollectionInitializers.Dequeue();

                Console.WriteLine(value);
            }

            var csharp7 = new CSharp7();

            csharp7.OutVariable();

            var tuple = csharp7.Tuples("123abc");
            Console.WriteLine($"{tuple.numbers} {tuple.letters}");

            csharp7.Discards();

            csharp7.PatternMatching("12");

            TestRefLocalsAndReturns(csharp7);

            var list = new[] { 1, 8, 9, 0, 2, 5 };
            csharp7.LocalFunctions(list);
            foreach (var value in list)
                Console.WriteLine(value);

            Console.WriteLine(csharp7.MoreExpressionBodiedMembers);

            csharp7.ThrowExpressions(1);

            var result = await csharp7.GeneralizedAsyncReturnTypes();
            Console.WriteLine(result);

            csharp7.NumericLiteralSyntaxImprovements();

            var csharp71 = new CSharp7_1();

            //csharp71 async Main method
            csharp71.DefaultLiteralExpressions();
            csharp71.InferredTupleElementNames();

            Console.ReadKey();
        }

        public static void TestRefLocalsAndReturns(CSharp7 csharp7)
        {
            var list = new[] { 1, 8, 9, 0, 2, 5 };
            ref var nine = ref csharp7.RefLocalsAndReturns(list, i => i == 9);

            nine = 18;

            foreach (var value in list)
                Console.WriteLine(value);
        }
    }
}
