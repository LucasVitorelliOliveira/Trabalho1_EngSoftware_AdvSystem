using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvSystem.Data;
using AdvSystem.Models;
using Xceed.Words.NET;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AdvSystem.Controllers
{
    public class EntradaCaixaController : Controller
    {
        private readonly Context _context;

        public EntradaCaixaController(Context context)
        {
            _context = context;
        }

        // GET: EntradaCaixa
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntradasCaixa.ToListAsync());
        }

        // GET: EntradaCaixa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradaCaixa = await _context.EntradasCaixa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaCaixa == null)
            {
                return NotFound();
            }

            return View(entradaCaixa);
        }

        // GET: EntradaCaixa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntradaCaixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,MetodoPagamento,Descricao,Data,ClienteId,UsusarioId")] EntradaCaixa entradaCaixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaCaixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entradaCaixa);
        }

        // GET: EntradaCaixa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradaCaixa = await _context.EntradasCaixa.FindAsync(id);
            if (entradaCaixa == null)
            {
                return NotFound();
            }
            return View(entradaCaixa);
        }

        // POST: EntradaCaixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,MetodoPagamento,Descricao,Data,ClienteId,UsusarioId")] EntradaCaixa entradaCaixa)
        {
            if (id != entradaCaixa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaCaixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaCaixaExists(entradaCaixa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entradaCaixa);
        }

        // GET: EntradaCaixa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradaCaixa = await _context.EntradasCaixa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaCaixa == null)
            {
                return NotFound();
            }

            return View(entradaCaixa);
        }

        // POST: EntradaCaixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entradaCaixa = await _context.EntradasCaixa.FindAsync(id);
            if (entradaCaixa != null)
            {
                _context.EntradasCaixa.Remove(entradaCaixa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Relatorio()
        {
            List<EntradaCaixa> listaClientes = await _context.EntradasCaixa.ToListAsync();

            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 40);
            string caminho = @"C:\pdf\" + "relatorio.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.HELVETICA, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("RELATÓRIO\n\n");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            string conteudo = "Relatório de entrada de valores do escritório\n\n";
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table = new PdfPTable(3);
            foreach(var item in listaClientes)
            {
                table.AddCell(
                    "Cliente: " + item.ClienteId +
                    "\nValor: " + item.Valor +
                    "\nDescrição: " + item.Descricao
                    );
            }
            doc.Add(table);

            doc.Close();

            return RedirectToAction(nameof(Index));
        }

        private bool EntradaCaixaExists(int id)
        {
            return _context.EntradasCaixa.Any(e => e.Id == id);
        }
    }
}
