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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AdvSystem.Controllers
{
    [AdvLogado]
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
            var context = _context.EntradasCaixa.Include(e => e.PessoaFisica).Include(e => e.PessoaJuridica);
            return View(await context.ToListAsync());
        }

        public IActionResult EscolherPessoa()
        {
            return View();
        }

        // GET: EntradaCaixa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradaCaixa = await _context.EntradasCaixa
                .Include(e => e.PessoaFisica)
                .Include(e => e.PessoaJuridica)
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
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome");
            return View();
        }

        // POST: EntradaCaixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,MetodoPagamento,Descricao,Data,ClienteId,ClienteJId")] EntradaCaixa entradaCaixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaCaixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", entradaCaixa.ClienteId);
            return View(entradaCaixa);
        }
        public IActionResult CreatePJ()
        {
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial");
            return View();
        }

        // POST: EntradaCaixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePJ([Bind("Id,Valor,MetodoPagamento,Descricao,Data,ClienteId,ClienteJId")] EntradaCaixa entradaCaixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaCaixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", entradaCaixa.ClienteId);
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
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", entradaCaixa.ClienteId);
            return View(entradaCaixa);
        }

        // POST: EntradaCaixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,MetodoPagamento,Descricao,Data,ClienteId,ClienteJId")] EntradaCaixa entradaCaixa)
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
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", entradaCaixa.ClienteId);
            return View(entradaCaixa);
        }
        // GET: EntradaCaixa/Edit/5
        public async Task<IActionResult> EditPJ(int? id)
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
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", entradaCaixa.ClienteId);
            return View(entradaCaixa);
        }

        // POST: EntradaCaixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPJ(int id, [Bind("Id,Valor,MetodoPagamento,Descricao,Data,ClienteId,ClienteJId")] EntradaCaixa entradaCaixa)
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
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", entradaCaixa.ClienteId);
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
                .Include(e => e.PessoaFisica)
                .Include(e => e.PessoaJuridica)
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
            var context = _context.EntradasCaixa.Include(e => e.PessoaFisica).Include(e => e.PessoaJuridica);
            List<EntradaCaixa> entrada = await context.ToListAsync();

            int total = 0;

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

            Paragraph par = new Paragraph("", new Font(Font.FontFamily.HELVETICA, 12));
            par.Alignment = Element.ALIGN_CENTER;
            string cont = "Relatório de entrada de valores do escritorio\n\n" + "Total de Clientes: " + entrada.Count + "\n\n";
            par.Add(cont);
            doc.Add(par);

            PdfPTable table = new PdfPTable(1);
            foreach (var i in entrada)
            {
                if (i.ClienteId != null)
                {
                    table.AddCell(
                    "Cliente: " + i.PessoaFisica.Nome +
                    "\nValor: " + i.Valor +
                    "\nMétodo de Pagamento: " + i.MetodoPagamento +
                    "\nData: " + i.Data.ToLongDateString() +
                    "\nDescrição: " + i.Descricao);
                }
                else
                {
                    table.AddCell(
                    "Cliente: " + i.PessoaJuridica.RazaoSocial +
                    "\nValor: " + i.Valor +
                    "\nMétodo de Pagamento: " + i.MetodoPagamento +
                    "\nData: " + i.Data.ToLongDateString() +
                    "\nDescrição: " + i.Descricao);
                }
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

        private bool EntradaCaixaExists(int id)
        {
            return _context.EntradasCaixa.Any(e => e.Id == id);
        }
    }
}
