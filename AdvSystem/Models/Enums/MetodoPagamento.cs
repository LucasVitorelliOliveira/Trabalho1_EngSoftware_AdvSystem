using System.ComponentModel.DataAnnotations;

namespace AdvSystem.Models.Enums
{
    public enum MetodoPagamento
    {
        [Display(Name = "Cédula")]
        Cedula = 1,
        [Display(Name = "Débito")]
        Debito,
        [Display(Name = "Crédito")]
        Credito,
        Cheque
    }
}
