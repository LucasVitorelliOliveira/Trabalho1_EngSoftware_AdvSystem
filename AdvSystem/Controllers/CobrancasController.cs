using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvSystem.Data;
using AdvSystem.Models;
using AdvSystem.Filters;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace AdvSystem.Controllers
{
    [UsuarioLogado]
    public class CobrancasController : Controller
    {
        private readonly Context _context;

        public CobrancasController(Context context)
        {
            _context = context;
        }

        // GET: Cobrancas
        public async Task<IActionResult> Index()
        {
            var context = _context.Cobrancas.Include(c => c.Processos);
            return View(await context.ToListAsync());
        }

        // GET: Cobrancas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobrancas
                .Include(c => c.Processos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobranca == null)
            {
                return NotFound();
            }

            return View(cobranca);
        }

        // GET: Cobrancas/Create
        public IActionResult Create()
        {
            ViewData["ProcessoId"] = new SelectList(_context.GereciamentoProcessos, "Id", "NumeroProcesso");
            return View();
        }

        // POST: Cobrancas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,JurosPrazo,Data,Parcela,Pago,ValorAtualizado,ProcessoId")] Cobranca cobranca)
        {
            Parcelas(cobranca);
            Juros(cobranca);
            _context.Add(cobranca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["ProcessoId"] = new SelectList(_context.GereciamentoProcessos, "Id", "NumeroProcesso", cobranca.ProcessoId);
            return View(cobranca);
        }

        [AdvLogado]
        // GET: Cobrancas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobrancas.FindAsync(id);
            if (cobranca == null)
            {
                return NotFound();
            }
            ViewData["ProcessoId"] = new SelectList(_context.GereciamentoProcessos, "Id", "NumeroProcesso", cobranca.ProcessoId);
            return View(cobranca);
        }

        [AdvLogado]
        // POST: Cobrancas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,JurosPrazo,Data,Parcela,Pago,ValorAtualizado,ProcessoId")] Cobranca cobranca)
        {
            if (id != cobranca.Id)
            {
                return NotFound();
            }

            try
            {
                Parcelas(cobranca);
                Juros(cobranca);
                _context.Update(cobranca);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobrancaExists(cobranca.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            ViewData["ProcessoId"] = new SelectList(_context.GereciamentoProcessos, "Id", "NumeroProcesso", cobranca.ProcessoId);
            return View(cobranca);
        }

        [AdvLogado]
        // GET: Cobrancas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobrancas
                .Include(c => c.Processos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobranca == null)
            {
                return NotFound();
            }

            return View(cobranca);
        }

        [AdvLogado]
        // POST: Cobrancas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cobranca = await _context.Cobrancas.FindAsync(id);
            if (cobranca != null)
            {
                _context.Cobrancas.Remove(cobranca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public void Parcelas(Cobranca cobranca)
        {
            if (cobranca.Parcela >= 1)
            {
                cobranca.ValorAtualizado = cobranca.Valor / cobranca.Parcela;
            }
            else
            {
                cobranca.ValorAtualizado = cobranca.Valor;
            }

        }

        public void Juros(Cobranca cobranca)
        {
            if (cobranca.JurosPrazo >= 1)
            {
                cobranca.ValorAtualizado += (cobranca.Valor * (cobranca.JurosPrazo / 100));
            }
            else
            {
                cobranca.ValorAtualizado = cobranca.Valor;
            }
        }

        public async Task<IActionResult> Relatorio()
        {
            var context = _context.Cobrancas.Include(c => c.Processos);
            List<Cobranca> entrada = await context.ToListAsync();

            float total = 0.0f;

            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 40);
            string caminho = @"C:\pdf\" + "relatorioCobrancas.pdf";
            if (System.IO.File.Exists(caminho))
            {
                int i = 1;
                while (true)
                {
                    caminho = @"C:\pdf\" + "relatorioCobrancas-" + i.ToString() + ".pdf";
                    if (!System.IO.File.Exists(caminho))
                    {
                        caminho = @"C:\pdf\" + "relatorioCobrancas-" + i.ToString() + ".pdf";
                        break;
                    }
                    i++;
                }
            }
            else
            {
                caminho = @"C:\pdf\" + "relatorioCobrancas.pdf";
            }

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.HELVETICA, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("RELATÓRIO\n\n");
            doc.Add(titulo);

            Paragraph par = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            par.Alignment = Element.ALIGN_CENTER;
            string cont = "Relatório de valores em aberto dos clientes\n\n" + "Total de Clientes: " + entrada.Count + "\n\n";
            par.Add(cont);
            doc.Add(par);

            PdfPTable table = new PdfPTable(1);
            foreach (var i in entrada)
            {
                string pg;
                if (i.Pago == true) pg = "sim";
                else pg = "não";
                table.AddCell(
                "Cliente: " + i.Processos.NumeroProcesso +
                "\nValor: " + i.Valor +
                "\nJuros: " + i.JurosPrazo +
                "\nData Prazo: " + i.Data.ToLongDateString() +
                "\nParcelas: " + i.Parcela +
                "\nPago: " + pg + 
                "\nValor Atualizado: " + i.ValorAtualizado);

                total += i.Valor;
            }
            doc.Add(table);

            Paragraph val = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            string contv = "Valores Totais: R$" + total + "\n\n";
            val.Alignment = Element.ALIGN_CENTER;
            val.Add(contv);
            doc.Add(val);

            doc.Close();

            return RedirectToAction(nameof(Index));
        }

        private bool CobrancaExists(int id)
        {
            return _context.Cobrancas.Any(e => e.Id == id);
        }
    }
}
