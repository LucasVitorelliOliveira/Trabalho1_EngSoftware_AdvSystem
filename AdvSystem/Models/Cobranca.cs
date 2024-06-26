﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvSystem.Models
{
    [Table("Cobrancas")]
    public class Cobranca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public float Valor { get; set; }

        [Display(Name = "Juros da Parcela")]
        public float JurosPrazo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Prazo")]
        public DateTime Data { get; set; }
        public float Parcela { get; set; }
        public bool Pago { get; set; }
        [Display(Name = "Valor Atualizado")]
        public float? ValorAtualizado { get; set; }

        //Fk
        public int ProcessoId { get; set; }
        [ForeignKey("ProcessoId")]
        public GerenciaProcesso Processos { get; set; }
    }
}
