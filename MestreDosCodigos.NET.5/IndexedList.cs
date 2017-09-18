using System;
using System.Collections;
using System.Collections.Generic;

namespace MestreDosCodigos.NET._5
{
    public class IndexedList : IEnumerable<string>
    {
        private IDictionary<int, string> _values = new Dictionary<int, string>
        {
            [1] = "Valor1",
            [2] = "Valor2",
            [3] = "Valor3"
        };

        public string this[int id] =>
            _values[id];

        public IEnumerator<string> GetEnumerator() =>
            _values.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
