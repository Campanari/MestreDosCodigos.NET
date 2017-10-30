namespace MestreDosCodigos.NET._14
{
    public class PedidoFakeRepositorio : IPedidoRepositorio
    {
        public void Salvar(Pedido pedido)
        {
            System.Console.WriteLine("Pedido salvo como Fake");
        }
    }
}
