using System.Collections.Generic;

namespace MestreDosCodigos.NET._13
{
    public class Pedido
    {
        public Pedido(ulong id)
        {
            Id = id;
            Itens = new List<Item>();
        }

        public Pedido()
        {
                
        }

        public ulong Id { get; set; }

        public List<Item> Itens { get; set; }
    }
}
