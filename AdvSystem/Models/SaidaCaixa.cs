using AdvSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvSystem.Models
{
    [Table("Saida_de_Caixa")]
    public class SaidaCaixa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int Valor { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Método de Pagamento")]
        public MetodoPagamento MetodoPagamento { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Descrção")]
        public string Descricao { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [Display(Name = "Data da Transação")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool Sangria { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }
    }
}
