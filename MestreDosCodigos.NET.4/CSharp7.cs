using System;
using System.Linq;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._4
{
    /// <summary>
    /// What's New in C# 7
    /// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7
    /// </summary>
    public class CSharp7
    {
        public void OutVariable()
        {
            const string text = "123";

            if (int.TryParse(text, out var number))
                Console.WriteLine($"Number: {number}");
        }

        public (int letters, int numbers) Tuples(string text) =>
            (text.Count(char.IsLetter), text.Count(char.IsNumber));

        public void Discards()
        {
            const string text = "shgd7t2u";

            var (_, numbers) = Tuples(text);

            Console.WriteLine($"Number: {numbers}");
        }

        public void PatternMatching(object value)
        {
            switch (value)
            {
                case int number:
                    Console.WriteLine($"Number: {number}");
                    break;
                case decimal number when number > 10m:
                    Console.WriteLine($"Number: {number}");
                    break;
                case bool boolean:
                    Console.WriteLine($"Boolean: {boolean}");
                    break;
                case null:
                    Console.WriteLine("null");
                    break;
                default:
                    Console.WriteLine("Unknown value");
                    break;
            }

            if (value is int numberIf)
            {
                Console.WriteLine($"Number: {numberIf}");
            }
        }

        public ref int RefLocalsAndReturns(int[] vector, Func<int, bool> predicate)
        {
            for (var i = 0; i < vector.Length; ++i)
            {
                if (predicate.Invoke(vector[i]))
                    return ref vector[i];
            }

            throw new InvalidOperationException();
        }

        public void LocalFunctions(int[] list)
        {
            QuickSort(0, list.Length - 1);

            // https://pt.wikipedia.org/wiki/Quicksort
            void QuickSort(int initialPosition, int finalPosition)
            {
                var i = initialPosition;
                var j = finalPosition;
                var pivo = list[(initialPosition + finalPosition) % 2];

                while (i < j)
                {
                    while (list[i] <= pivo)
                        i = i + 1;

                    while (list[j] > pivo)
                        j = j - 1;

                    if (i < j)
                    {
                        var aux = list[i];
                        list[i] = list[j];
                        list[j] = aux;
                    }

                    i = i + 1;
                    j = j - 1;
                }

                if (j > initialPosition)
                    QuickSort(initialPosition, j);
             
                if (i < finalPosition)
                    QuickSort(j + 1, finalPosition);
            }
        }


        private string _moreExpressionBodiedMembers;
        public string MoreExpressionBodiedMembers
        {
            get => _moreExpressionBodiedMembers;
            set => _moreExpressionBodiedMembers = value ?? "Padrão";
        }

        public void ThrowExpressions(object value)
        {
            var temp = value ?? throw new ArgumentNullException(nameof(value));

            Console.WriteLine(temp);
        }

        public async ValueTask<int> GeneralizedAsyncReturnTypes()
        {
            await Task.Delay(100);
            return 5;
        }

        public void NumericLiteralSyntaxImprovements()
        {
            var binary10 = 0b0000_1010;
            var integerSeparator = 1_000_000_000;
            var decimalSeparator = 0.000_090;
        }
    }
}
