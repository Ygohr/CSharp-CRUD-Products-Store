using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDProdutos.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Produto")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A quantidade do produto é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Quantidade")]        
        public int quantidade { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto", AllowEmptyStrings = false)]
        [Display(Name = "Preço")]        
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public double preco { get; set; }

        public int idPromocao { get; set; }

        public virtual Promocao promocao { get; set; }
    }
}