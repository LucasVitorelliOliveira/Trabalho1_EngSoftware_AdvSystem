using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvSystem.Models
{
    [Table("Pessoa_Fisica")]
    public class PessoaFisica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(50, ErrorMessage = "Limite máximo de caracteres excedido!")]
        [MinLength(3, ErrorMessage = "O campo deve conter no mínimo 3 caracteres!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(50, ErrorMessage = "Limite máximo de caracteres excedido!")]
        [MinLength(3, ErrorMessage = "O campo deve conter no mínimo 3 caracteres!")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(9, ErrorMessage = "Limite máximo de caracteres excedido!")]
        public string Rg { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(11, ErrorMessage = "Limite máximo de caracteres excedido!")]
        public string Cpf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [MaxLength(11, ErrorMessage = "Limite máximo de caracteres excedido!")]
        [MinLength(8, ErrorMessage = "O campo deve conter no mínimo 8 caracteres!")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(13, ErrorMessage = "Limite máximo de caracteres excedido!")]
        [MinLength(9, ErrorMessage = "O campo deve conter no mínimo 9 caracteres!")]
        [Display(Name = "Celular")]
        public string Celular { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "Limite máximo de caracteres excedido!")]
        public string Email { get; set; } = string.Empty;

        //Endereço
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(2, ErrorMessage = "Digite apenas a sigla do estado!")]
        [MinLength(2, ErrorMessage = "O campo deve conter no mínimo 2 caracteres!")]
        [Display(Name = "Estado")]
        public string Uf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(5, ErrorMessage = "O campo deve conter no mínimo 5 caracteres!")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(5, ErrorMessage = "O campo deve conter no mínimo 5 caracteres!")]
        [Display(Name = "Rua")]
        public string Rua { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Número")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(5, ErrorMessage = "O campo deve conter no mínimo 5 caracteres!")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; } = string.Empty;
    }
}
