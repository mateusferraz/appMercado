using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppMercado.Models
{
    public class Pedido
    {
        [Key]
        [Required]
        public int idPedido { get; set; }


        public int numeroPedido { get; set; }

        public string observacao { get; set; }

        public int status { get; set; }
        public DataType dataPedido { get; set; }

        [Required]
        public virtual Pessoa pessoa { get; set; }
        public List<ItemPedido> itens { get; set; }
    }
}
