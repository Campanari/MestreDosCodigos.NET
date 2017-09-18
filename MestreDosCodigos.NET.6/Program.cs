using System;

namespace MestreDosCodigos.NET._6
{
    class Program
    {
        static void Main(string[] args)
        {
            var pedido = new Pedido
            {
                new Item(1ul, 1u, 10m),
                new ItemPromocional(2ul, 10u, 89m, 10m),
                new Item(3ul, 2u, 12m),
                new Item(4ul, 5u, 34m),
                new ItemPromocional(5ul, 1u, 100m, 5m)
            };

            Console.WriteLine($"Valor Total: {pedido.ValorTotal:C}");

            pedido.Add(new Item(6ul, 2u, 20m));
            
            Console.WriteLine($"Valor Total: {pedido.ValorTotal:C}");

            if (pedido[2ul] is Item item)
                item.Zerar();

            Console.WriteLine($"Valor Total: {pedido.ValorTotal:C}");

            Console.ReadKey();
        }
    }
}
