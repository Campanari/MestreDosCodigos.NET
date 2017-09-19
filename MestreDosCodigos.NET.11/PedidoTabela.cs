using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MestreDosCodigos.NET._11
{
    [Table("Pedido")]
    public class PedidoTabela
    {
        public int Id { get; set; }
        
        public List<ItemTabela> Itens { get; set; }
    }
}
