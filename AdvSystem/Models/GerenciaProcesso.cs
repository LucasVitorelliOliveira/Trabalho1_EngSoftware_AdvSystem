using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvSystem.Models
{
    [Table("Controle_de_Processos")]
    public class GerenciaProcesso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; } = string.Empty;
        [Display(Name = "Descrição")]
        public string? Descricao{ get; set; }
        [Display(Name = "Movimentações")]
        public string? Movimentacoes { get; set; }

        //Fk
        public int? ClienteId { get; set; }
        public int? ClienteJId { get; set; }
        [ForeignKey("ClienteId")]
        public PessoaFisica? PessoaFisica { get; set; }
        [ForeignKey("ClienteJId")]
        public PessoaJuridica? PessoaJuridica { get; set; }
    }
}
