using System;
using System.ComponentModel.DataAnnotations;

namespace AppMercado.Models
{
    public class Produto
    {
        [Required]
        [Key]
        public int id { get; set; }

        [Required]
        public string nome { get; set; }

        public string descricao { get; set; }

        [Required]
        public decimal valor { get; set; }
        public string srcImage { get; set; }
        public DateTime dataCadastro { get; set; }


    }
}
