namespace MestreDosCodigos.NET._6
{
    public class ItemPromocional: Item, IItemPromocional
    {
        public ItemPromocional(ulong id, uint quantidade, decimal valorUnitario, decimal desconto)
            : base(id, quantidade, valorUnitario)
        {
            Desconto = desconto;
        }
        
        public decimal Desconto { get; }

        public override decimal ValorTotal => Quantidade * ValorUnitario * (1m - Desconto / 100m);
    }
}
