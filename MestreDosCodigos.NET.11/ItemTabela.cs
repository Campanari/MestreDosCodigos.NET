using System.ComponentModel.DataAnnotations.Schema;

namespace MestreDosCodigos.NET._11
{
    [Table("Item")]
    public class ItemTabela
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }

        public PedidoTabela Pedido { get; set; }
    }
}
