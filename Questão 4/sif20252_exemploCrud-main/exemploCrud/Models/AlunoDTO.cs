using exemploCrud.Validations;
using exemploCrud.Validators;
using System.ComponentModel.DataAnnotations;

namespace exemploCrud.Models
{
    public class AlunoDTO
    {
        [Required(ErrorMessage = "RA Obrigatório")]
        [RaValidation]
        public string RA { get; set; }

        [EmailAddress(ErrorMessage = "Digite um email valido")]
        [Required(ErrorMessage = "Email Obrigatório")]
        public string Email { get; set; }

        [CpfValidation(ErrorMessage = "Digite um cpf valido")]
        [Required(ErrorMessage ="Cpf Obrigatório")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Cpf Obrigatório")]
        [MinLength(3, ErrorMessage ="Digite no minimo 3 letras")]
        [MaxLength(20, ErrorMessage ="Digite no maximo 20 letras")]
        public string nome { get; set; }

        [Range(18,80,ErrorMessage ="Digite idade entre 18 e 80 anos")]
        public int idade { get; set; }

        [Required(ErrorMessage = "Ativo Obrigatório")]
        public bool ativo { get; set; }

   
    }
}
