namespace MestreDosCodigos.NET._6
{
    public interface IItem
    {
        ulong Id { get; }

        uint Quantidade { get; }

        decimal ValorUnitario { get; }

        decimal ValorTotal { get; }
    }
}
