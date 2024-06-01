using AdvSystem.Models.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvSystem.Models
{
    [Table("Entrada_de_Caixa")]
    public class EntradaCaixa
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
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Usuário")]
        public int UsusarioId { get; set; }
    }
}
