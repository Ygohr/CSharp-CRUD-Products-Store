using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDProdutos.Models
{
    [Table("Promocao")]
    public class Promocao
    {
        [Key]
        public int idPromocao { get; set; }
        [Display(Name = "Promoção")]
        public string descricao { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}