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
        public string NumeroProcesso { get; set; } = string.Empty;

        public string Apensos { get; set; } = string.Empty;
        public List<int> pgDecisao { get; set; } = new List<int>();
        public List<int> pgAcordao { get; set; } = new List<int>();
        public List<int> pgSentenca { get; set; } = new List<int>();
        public List<int> pgDiligencias { get; set; } = new List<int>();
        public List<int> pgRecursos { get; set; } = new List<int>();

        //FK
        [Display(Name = "Parte")]
        public int ClienteId { get; set; }
    }
}
