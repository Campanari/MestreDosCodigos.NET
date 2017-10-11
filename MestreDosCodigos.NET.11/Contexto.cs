using Microsoft.EntityFrameworkCore;

namespace MestreDosCodigos.NET._11
{
    public class Contexto : DbContext
    {
        private readonly string _nameOrConnectionString;

        public Contexto(string nameOrConnectionString)
        {
            _nameOrConnectionString = nameOrConnectionString;
        }

        public DbSet<PedidoTabela> Pedidos { get; set; }
        public DbSet<ItemTabela> Itens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_nameOrConnectionString);
        }
    }
}
