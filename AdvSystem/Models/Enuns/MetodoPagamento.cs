using System.ComponentModel.DataAnnotations;

namespace AdvSystem.Models.Enuns
{
    public enum MetodoPagamento
    {
        [Display(Name = "Cédula")]
        Cedula = 1,
        [Display(Name = "Débito")]
        Debito = 2,
        [Display(Name = "Crédito")]
        Credito = 3,
        Cheque = 4
    }
}
