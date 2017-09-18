using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Math;

namespace MestreDosCodigos.NET._4
{
    /// <summary>
    /// What's New in C# 6
    /// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6
    /// </summary>
    public class CSharp6
    {
        public string ReadOnlyAutoProperty { get; }

        public string AutoPropertyInitializers { get; set; } = "Initialized";

        public string ExpressionBodiedMemberReadOnlyProperty => "";
        public string ExpressionBodiedFunction() => "";

        public double UsingStatic => E;

        public int NullConditionalOperators => "ASD"?.Length ?? 0;

        public string StringInterpolation => $"Valor de E {E}";
        public FormattableString StringInterpolationFormattableString => $"Valor de E {E}";
        public string StringInterpolationSpecificCulture => string.Format(CultureInfo.GetCultureInfo("en-us"), StringInterpolationFormattableString.Format, StringInterpolationFormattableString.GetArguments());

        public string ExceptionFilters()
        {
            try
            {
                var client = new HttpClient();

                var response = client.GetAsync(@"http://localhost:54115/api/values").GetAwaiter().GetResult();

                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return content;
            }
            catch (HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site movido";
            }
            catch (HttpRequestException e) when (e.Message.Contains("404"))
            {
                return "Site não encontrado";
            }
        }

        public string NameOfExpression => nameof(CSharp6);

        public async void AwaitInCatchAndFinallyBlocks()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {
                await Task.Delay(100);
            }
        }

        public List<string> IndexInitializerList => new List<string>
        {
            "1",
            "2",
            "3",
            "4"
        };

        public Dictionary<int, string> IndexInitializerDictionary => new Dictionary<int, string>
        {
            [1] = "1",
            [2] = "2",
            [3] = "3",
            [4] = "4"
        };
        
        public Task ImprovedOverloadResolution() => Task.Delay(10);

        public CSharp6()
        {
            ReadOnlyAutoProperty = "Initialized";
            Task.Run(ImprovedOverloadResolution);
        }
    }
}
