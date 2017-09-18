namespace MestreDosCodigos.NET._6
{
    public abstract class ItemBase : IItem
    {
        protected ItemBase(ulong id, uint quantidade, decimal valorUnitario)
        {
            Id = id;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public ulong Id { get; }

        public uint Quantidade { get; protected set; }

        public decimal ValorUnitario { get; }

        public virtual decimal ValorTotal => Quantidade * ValorUnitario;

        public abstract void Zerar();
    }
}
