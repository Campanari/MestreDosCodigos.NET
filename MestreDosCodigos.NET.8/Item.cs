using System;

namespace MestreDosCodigos.NET._8
{
    internal sealed class Item
    {
        public Item(ulong id, ulong quantidade, decimal valorBruto)
        {
            Id = id;
            _quantidade = quantidade;
            ValorBruto = valorBruto;
        }

        public ulong Id { get; }

        public decimal ValorBruto { get; }

        private decimal _desconto;
        public decimal Desconto
        {
            get => _desconto;

            private set
            {
                if (_desconto == value) return;

                var valorAntigo = ValorLiquido;

                _desconto = value;
                
                ValorAlterado?.Invoke(this, new ValorAlteradoEventArgs(valorAntigo, ValorLiquido));
            }
        }

        public decimal ValorLiquido => ValorBruto * (1m - Desconto / 100m);

        public decimal ValorBrutoTotal => Quantidade * ValorBruto;

        public decimal ValorLiquidoTotal => Quantidade * ValorLiquido;
        
        private ulong _quantidade;
        public ulong Quantidade
        {
            get => _quantidade;

            set
            {
                if (_quantidade == value) return;

                _quantidade = value;
                
                QuantidadeAlterada?.Invoke(this, EventArgs.Empty);
            }
        }

        internal event EventHandler QuantidadeAlterada;

        internal event EventHandler<ValorAlteradoEventArgs> ValorAlterado;

        internal void Registrar(Pedido pedido)
        {
            pedido.DescontoGeralAlterado -= PedidoOnDescontoGeralAlterado;
            pedido.DescontoGeralAlterado += PedidoOnDescontoGeralAlterado;
        }

        private void PedidoOnDescontoGeralAlterado(object sender, decimal desconto) =>
            Desconto = desconto;
    }
}