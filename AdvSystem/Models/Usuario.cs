using AdvSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvSystem.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
        public string Senha { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataAtualizacao { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
