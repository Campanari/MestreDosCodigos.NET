using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MestreDosCodigos.NET._6
{
    public sealed class Pedido : IEnumerable<IItem>
    {
        private readonly IDictionary<ulong, IItem> _itens = new ConcurrentDictionary<ulong, IItem>();

        public void Add<T>(T item) where T : class, IItem =>
            _itens[item.Id] = item;

        internal IItem this[ulong id] =>
            _itens[id];

        public decimal ValorTotal => _itens.Values.Sum(i => i.ValorTotal);

        IEnumerator<IItem> IEnumerable<IItem>.GetEnumerator() =>
            _itens.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _itens.GetEnumerator();
    }
}
