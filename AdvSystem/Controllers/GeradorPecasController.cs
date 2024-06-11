using AdvSystem.Data;
using AdvSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Xceed.Words.NET;
using System.IO;
using AdvSystem.Filters;

namespace AdvSystem.Controllers
{
    [UsuarioLogado]
    public class GeradorPecasController : Controller
    {
        private readonly Context _context;

        public GeradorPecasController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
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
                var doc = DocX.Load(dir + @"\Documentos\" + "Procuracao.DOC");
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

                string arqAtual = @"C:\pdf\" + "Procuracao.docx";
                TempData["menssagem"] = @"OK, Verifique o documento no diretório C:\pdf";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "Procuracao-" + i.ToString() + ".docx";
                        TempData["menssagem"] = @"OK, Verifique o documento no diretório C:\pdf";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "Procuracao-" + i.ToString() + ".docx");
                            TempData["menssagem"] = @"OK, Verifique o documento no diretório C:\pdf";
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "Procuracao.docx");
                    TempData["menssagem"] = @"OK, Verifique o documento no diretório C:\pdf";
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }
            TempData["menssagem"] = @"OK, Verifique o documento no diretório C:\pdf";

            return RedirectToAction(nameof(Index));
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

                string arqAtual = @"C:\pdf\" + "Recibo.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "Recibo-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "Recibo-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "Recibo.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AECPF(int? id)
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
                var doc = DocX.Load(dir + @"\Documentos\" + "AcaoExContrato.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#sobrenome", pessoaFisica.Sobrenome);
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = @"C:\pdf\" + "AcaoExContrato.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "AcaoExContrato-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "AcaoExContrato-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "AcaoExContrato.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CSPF(int? id)
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
                var doc = DocX.Load(dir + @"\Documentos\" + "ContratoSimples.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#sobrenome", pessoaFisica.Sobrenome);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = @"C:\pdf\" + "ContratoSimples.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "ContratoSimples-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "ContratoSimples-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "ContratoSimples.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CPP(int? id)
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
                var doc = DocX.Load(dir + @"\Documentos\" + "ContratoPrev.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#sobrenome", pessoaFisica.Sobrenome);
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = @"C:\pdf\" + "ContratoPrev.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "ContratoPrev-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "ContratoPrev-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "ContratoPrev.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> HA(int? id)
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
                var doc = DocX.Load(dir + @"\Documentos\" + "HabilitacaoAdvogado.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#sobrenome", pessoaFisica.Sobrenome);
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = @"C:\pdf\" + "HabilitacaoAdvogado.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "HabilitacaoAdvogado-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "HabilitacaoAdvogado-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "HabilitacaoAdvogado.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> JS(int? id)
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
                var doc = DocX.Load(dir + @"\Documentos\" + "JuntadaSub.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#sobrenome", pessoaFisica.Sobrenome);
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = @"C:\pdf\" + "JuntadaSub.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "JuntadaSub-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "JuntadaSub-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "JuntadaSub.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> PCC(int? id)
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
                var doc = DocX.Load(dir + @"\Documentos\" + "ProcuracaoCriminal.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#sobrenome", pessoaFisica.Sobrenome);
                doc.ReplaceText("#rg", pessoaFisica.Rg);
                doc.ReplaceText("#cpf", pessoaFisica.Cpf);
                doc.ReplaceText("#uf", pessoaFisica.Uf);
                doc.ReplaceText("#bairro", pessoaFisica.Bairro);
                doc.ReplaceText("#numero", pessoaFisica.Numero.ToString());
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = @"C:\pdf\" + "ProcuracaoCriminal.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "ProcuracaoCriminal-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "ProcuracaoCriminal-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "ProcuracaoCriminal.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RSA(int? id)
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
                var doc = DocX.Load(dir + @"\Documentos\" + "ReciboServicosAut.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#sobrenome", pessoaFisica.Sobrenome);
                doc.ReplaceText("#rg", pessoaFisica.Rg);
                doc.ReplaceText("#uf", pessoaFisica.Uf);
                doc.ReplaceText("#bairro", pessoaFisica.Bairro);
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = @"C:\pdf\" + "ReciboServicosAut.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "ReciboServicosAut-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "ReciboServicosAut-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "ReciboServicosAut.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> PR(int? id)
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
                var doc = DocX.Load(dir + @"\Documentos\" + "Renuncia.docx");
                doc.ReplaceText("#nome", pessoaFisica.Nome);
                doc.ReplaceText("#cidade", pessoaFisica.Cidade);
                doc.ReplaceText("#data", DateTime.UtcNow.ToLongDateString());

                string arqAtual = @"C:\pdf\" + "Renuncia.docx";
                if (System.IO.File.Exists(arqAtual))
                {
                    int i = 1;
                    while (true)
                    {
                        arqAtual = @"C:\pdf\" + "Renuncia-" + i.ToString() + ".docx";
                        if (!System.IO.File.Exists(arqAtual))
                        {
                            doc.SaveAs(@"C:\pdf\" + "Renuncia-" + i.ToString() + ".docx");
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    doc.SaveAs(@"C:\pdf\" + "Renuncia.docx");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível inicializar o documento!");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
