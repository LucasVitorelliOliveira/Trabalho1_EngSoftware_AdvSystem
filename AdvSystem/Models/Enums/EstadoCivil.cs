using System.ComponentModel.DataAnnotations;

namespace AdvSystem.Models.Enums
{
    public enum EstadoCivil
    {
        [Display(Name = "Solteiro(a)")]
        Solteiro = 1,
        [Display(Name = "Casado(a)")]
        Casado,
        [Display(Name = "União Estável")]
        UniaoEstavel,
        [Display(Name = "Divorciado(a)")]
        Divorciado,
        [Display(Name = "Viúvo(a)")]
        Viuvo
    }
}
