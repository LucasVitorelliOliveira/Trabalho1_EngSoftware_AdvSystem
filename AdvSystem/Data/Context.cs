using AdvSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvSystem.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> op) : base(op) { }

        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<GerenciaProcesso> GereciamentoProcessos { get; set; }
        public DbSet<SaidaCaixa> SaidasCaixa { get; set; }
        public DbSet<EntradaCaixa> EntradasCaixa { get; set; }
        public DbSet<Cobranca> Cobrancas { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
    }
}
