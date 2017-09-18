namespace MestreDosCodigos.NET._6
{
    public class Item : ItemBase
    {
        internal Item(ulong id, uint quantidade, decimal valorUnitario)
            : base(id, quantidade, valorUnitario)
        {

        }


        public override void Zerar() =>
            Quantidade = 0u;
    }
}
