using System.ComponentModel.DataAnnotations;

namespace AppMercado.Models
{
    public class ItemPedido
    {
        [Key]
        [Required]
        public int idItem { get; set; }
        public int quantidade { get; set; }
        public decimal valorUnitario { get; set; }
        public Pedido pedido { get; set; }
        public Produto  produto { get; set; }
    }
}
