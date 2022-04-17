using System.ComponentModel.DataAnnotations;

namespace AppMercado.Models
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int idPessoa { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DataType dataCadastro { get; set; }
        public virtual Pedido pedido { get; set; }
    }
}
