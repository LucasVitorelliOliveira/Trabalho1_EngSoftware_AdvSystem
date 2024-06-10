using AdvSystem.Data;
using AdvSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Xceed.Words.NET;
using System.IO;

namespace AdvSystem.Controllers
{
    public class GeradorPecasController : Controller
    {
        private readonly Context _context;

        public GeradorPecasController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListaPessoaFisica()
        {
            return View(await _context.PessoasFisicas.ToListAsync());
        }
        public async Task<IActionResult> ListaPecas(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        public async Task<IActionResult> ProcuracaoPessoaFisica(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            var dir = Directory.GetCurrentDirectory();
            try
            {
                var doc = DocX.Load(dir + @"\Documentos\" + "PROCURACAO.DOC");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#sobrenome", pessoaFisica.Sobrenome);
                doc.ReplaceText("#endereco", pessoaFisica.Rua);
                doc.ReplaceText("#numero", pessoaFisica.Numero.ToString());
                doc.ReplaceText("#bairro", pessoaFisica.Bairro);
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#estado", pessoaFisica.Uf);
                if(pessoaFisica.Email != null)
                {
                    doc.ReplaceText("#email", pessoaFisica.Email);
                }
                else
                {
                    doc.ReplaceText("#email", "(email)");
                }
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = dir + @"\Documentos\Salvos\" + "novo.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = dir + @"\Documentos\Salvos\" + "novo-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(dir + @"\Documentos\Salvos\" + "novo-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(dir + @"\Documentos\Salvos\" + "novo.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return View(pessoaFisica);
        }
        public async Task<IActionResult> ReciboPessoaFisica(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            var dir = Directory.GetCurrentDirectory();
            try
            {
                var doc = DocX.Load(dir + @"\Documentos\" + "Recibo.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#RG", pessoaFisica.Rg);
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = dir + @"\Documentos\Salvos\" + "novo.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = dir + @"\Documentos\Salvos\" + "novo-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(dir + @"\Documentos\Salvos\" + "novo-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(dir + @"\Documentos\Salvos\" + "novo.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return View(pessoaFisica);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
