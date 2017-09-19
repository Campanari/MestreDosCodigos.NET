using System;
using System.Threading;
using System.Threading.Tasks;

namespace MestreDosCodigos.NET._8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId:D2} {DateTime.Now} Pedido Iniciado!");

            var pedido = new Pedido
            {
                new Item(1ul, 3ul, 10m),
                new Item(2ul, 1ul, 3m),
                new Item(3ul, 10ul, 4.23m),
                new Item(4ul, 2ul, 1m),
                new Item(5ul, 1ul, 5m)
            };
            
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId:D2} {DateTime.Now} Pedido {{ Valor Bruto: {pedido.ValorBruto:C}, Valor Líquido: {pedido.ValorLiquido:C} }}");
            
            foreach (var item in pedido)
            {
                item.ValorAlterado -= Item_ValorAlterado;
                item.ValorAlterado += Item_ValorAlterado;
            }

            Task.WaitAll(
                Task.Factory.StartNew(() =>
                {
                    pedido.DescontoGeral = 10;
                    Console.WriteLine(
                        $"{Thread.CurrentThread.ManagedThreadId:D2} {DateTime.Now} Pedido {{ Valor Bruto: {pedido.ValorBruto:C}, Valor Líquido: {pedido.ValorLiquido:C} }}");
                }),
                Task.Factory.StartNew(() =>
                {
                    pedido.DescontoGeral = 9;
                    Console.WriteLine(
                        $"{Thread.CurrentThread.ManagedThreadId:D2} {DateTime.Now} Pedido {{ Valor Bruto: {pedido.ValorBruto:C}, Valor Líquido: {pedido.ValorLiquido:C} }}");
                }),
                Task.Factory.StartNew(() =>
                {
                    pedido.DescontoGeral = 2;
                    Console.WriteLine(
                        $"{Thread.CurrentThread.ManagedThreadId:D2} {DateTime.Now} Pedido {{ Valor Bruto: {pedido.ValorBruto:C}, Valor Líquido: {pedido.ValorLiquido:C} }}");
                }));
                
            pedido.DescontoGeral = 0;

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId:D2} {DateTime.Now} Pedido {{ Valor Bruto: {pedido.ValorBruto:C}, Valor Líquido: {pedido.ValorLiquido:C} }}");

            Console.ReadKey();
        }

        private static readonly object Lock = new object();
        private static void Item_ValorAlterado(object sender, ValorAlteradoEventArgs e)
        {
            lock(Lock)
            {
                if (sender is Item item)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId:D2} {DateTime.Now} Item {{ Id: {item.Id}, Valor Antigo: {e.ValorAntigo:C}, Valor Novo: {e.ValorNovo:C} }}");
                }
            }
        }
    }
}
