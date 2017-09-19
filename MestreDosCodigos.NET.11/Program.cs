using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._11
{
    class Program
    {
        private const string Connection = @"Server=(localdb)\mssqllocaldb;Database=Tarefa11;Trusted_Connection=True;";

        static async Task Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now} Inicializando!");

            using (var contexto = new Contexto(Connection))
            {
                contexto.Database.Log = s => Console.WriteLine($"{DateTime.Now} {s}");

                if (!await contexto.Pedidos.AnyAsync())
                    contexto.Pedidos.Add(
                        new PedidoTabela
                        {
                            Itens = new List<ItemTabela>
                            {
                                new ItemTabela(),
                                new ItemTabela(),
                                new ItemTabela()
                            }
                        });

                Console.WriteLine($"{DateTime.Now} Eager loading!");

                contexto.Configuration.LazyLoadingEnabled = false;

                var pedidoEager = await contexto.Pedidos
                    .Include(pedido => pedido.Itens)
                    .FirstAsync();

                Console.WriteLine($"{DateTime.Now} Explicit loading!");

                var pedidoExplicit = await contexto.Pedidos
                    .FirstAsync();

                await contexto.Entry(pedidoExplicit)
                    .Collection(pedido => pedido.Itens)
                    .LoadAsync();

                Console.WriteLine($"{DateTime.Now} Lazy loading!");

                contexto.Configuration.LazyLoadingEnabled = true;

                var pedidoLazy = await contexto.Pedidos
                    .FirstAsync();

                var itensLazy = pedidoLazy.Itens.ToList();
            }
            
            Console.WriteLine($"{DateTime.Now} Finalizado!");

            Console.ReadKey();
        }
    }
}
