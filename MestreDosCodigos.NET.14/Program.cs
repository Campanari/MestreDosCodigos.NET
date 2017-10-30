namespace MestreDosCodigos.NET._14
{
    class Program
    {
        static void Main(string[] args)
        {
            var pedido = new Pedido();

            System.Console.WriteLine("Pedido criado");

            var repositorio = PedidoRepositorioFabrica.Criar(pedido);

            System.Console.WriteLine("Repositorio criado");

            repositorio.Salvar(pedido);

            System.Console.ReadKey();
        }
    }
}
