using System.Data.Entity;

namespace MestreDosCodigos.NET._11
{
    public class Contexto : DbContext
    {
        public Contexto(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        public DbSet<PedidoTabela> Pedidos { get; set; }
        public DbSet<ItemTabela> Itens { get; set; }
    }
}
