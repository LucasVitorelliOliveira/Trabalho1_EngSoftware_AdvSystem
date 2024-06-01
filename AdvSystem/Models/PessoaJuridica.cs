using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvSystem.Models
{
    [Table("Pessoa_Juridica")]
    public class PessoaJuridica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(14, ErrorMessage = "Limite máximo de caracteres excedido!")]
        public string Cnpj { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; } = string.Empty;

        //Endereço Empresa
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

        //Representante Legal
        [Display(Name = "Representante Legal")]
        public int RepresentanteLegalId { get; set; }
        [ForeignKey("RepresentanteLegalId")]
        public PessoaFisica? RepresentanteLegal { get; set; }
    }
}
