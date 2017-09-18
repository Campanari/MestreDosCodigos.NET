using System;
using System.Data;

namespace MestreDosCodigos.NET._4
{
    /// <summary>
    /// What's New in C# 7.1
    /// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1
    /// </summary>
    public class CSharp7_1
    {
        //Async Main

        public void DefaultLiteralExpressions()
        {
            int integer = default;

            object @object = default;
        }

        public void InferredTupleElementNames()
        {
            const int width = 10;
            const int height = 3;

            var rectangle = (width, height);

            Console.WriteLine($"{rectangle.width}x{rectangle.height}");
        }
    }
}
