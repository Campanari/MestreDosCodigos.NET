using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MestreDosCodigos.NET._8
{
    internal sealed class Pedido : IEnumerable<Item>
    {
        private readonly IDictionary<ulong, Item> _itens = new ConcurrentDictionary<ulong, Item>();

        public event EventHandler<decimal> DescontoGeralAlterado;

        public decimal ValorBruto => _itens.Values.AsParallel().Sum(i => i.ValorBrutoTotal);
        public decimal ValorLiquido => _itens.Values.AsParallel().Sum(i => i.ValorLiquidoTotal);

        private decimal _descontoGeral;
        public decimal DescontoGeral
        {
            get => _descontoGeral;

            set
            {
                lock (_itens)
                {
                    if (_descontoGeral == value) return;

                    _descontoGeral = value;

                    DescontoGeralAlterado?.Invoke(this, DescontoGeral);
                }
            }
        }

        public void Add(Item item) => Adcionar(item);

        public void Adcionar(Item item)
        {
            lock (_itens)
            {
                if (item == null) return;

                _itens[item.Id] = item;

                item.Registrar(this);
            }
        }

        IEnumerator<Item> IEnumerable<Item>.GetEnumerator() =>
            _itens.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _itens.Values.GetEnumerator();
    }
}
