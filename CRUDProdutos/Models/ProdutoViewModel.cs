using System.ComponentModel.DataAnnotations;

namespace CRUDProdutos.Models
{
    public class ProdutoViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Produto")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A quantidade do produto é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto", AllowEmptyStrings = false)]
        [Display(Name = "Preço")]
        public double preco { get; set; }
        
        [Display(Name = "Promoção")]
        public int idPromocao { get; set; }
    }
}