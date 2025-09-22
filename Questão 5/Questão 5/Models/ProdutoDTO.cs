using System.ComponentModel.DataAnnotations;
using Questão_5.Validations;

namespace Questão_5.Models
{
    public class ProdutoDTO
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MinLength(3, ErrorMessage = "Descrição deve ter pelo menos 3 caracteres.")]
        [MaxLength(200, ErrorMessage = "Descrição não pode ultrapassar 200 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Estoque é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "Estoque não pode ser menor que zero.")]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "Código do produto é obrigatório.")]
        [ProdutoValidation]
        public string CodigoProduto { get; set; }
    }
}
