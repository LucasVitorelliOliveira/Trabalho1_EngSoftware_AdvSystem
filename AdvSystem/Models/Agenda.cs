using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdvSystem.Models
{
    public class Agenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Data e Hora")]
        public DateTime Data { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;
    }
}
