using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvSystem.Models
{
    [Table("Cobrancas")]
    public class Cobranca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Processo")]
        public int ProcessoId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public float Valor { get; set; }

        [Display(Name = "Juros da Parcela")]
        public float JurosPrazo { get; set; }
        [Display(Name = "Juros de Atraso")]
        public float JurosAtraso { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data da Transação")]
        public DateTime Data { get; set; }
        public float Parcela { get; set; }
        public bool Pago { get; set; }

        public float ValorAtualizado { get; set; }
    }
}
