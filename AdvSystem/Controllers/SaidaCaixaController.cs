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
    [AdvLogado]
    public class SaidaCaixaController : Controller
    {
        private readonly Context _context;

        public SaidaCaixaController(Context context)
        {
            _context = context;
        }

        // GET: SaidaCaixa
        public async Task<IActionResult> Index()
        {
            var context = _context.SaidasCaixa.Include(s => s.PessoaFisica).Include(s => s.PessoaJuridica);
            return View(await context.ToListAsync());
        }

        public IActionResult EscolherPessoa()
        {
            return View();
        }

        // GET: SaidaCaixa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaCaixa = await _context.SaidasCaixa
                .Include(s => s.PessoaFisica)
                .Include(s => s.PessoaJuridica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saidaCaixa == null)
            {
                return NotFound();
            }

            return View(saidaCaixa);
        }

        // GET: SaidaCaixa/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome");
            return View();
        }

        // POST: SaidaCaixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,MetodoPagamento,Descricao,Data,Sangria,ClienteId,ClienteJId")] SaidaCaixa saidaCaixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saidaCaixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", saidaCaixa.ClienteId);
            return View(saidaCaixa);
        }
        public IActionResult CreatePJ()
        {
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial");
            return View();
        }

        // POST: SaidaCaixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePJ([Bind("Id,Valor,MetodoPagamento,Descricao,Data,Sangria,ClienteId,ClienteJId")] SaidaCaixa saidaCaixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saidaCaixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", saidaCaixa.ClienteId);
            return View(saidaCaixa);
        }


        // GET: SaidaCaixa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaCaixa = await _context.SaidasCaixa.FindAsync(id);
            if (saidaCaixa == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", saidaCaixa.ClienteId);
            return View(saidaCaixa);
        }

        // POST: SaidaCaixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,MetodoPagamento,Descricao,Data,Sangria,ClienteId,ClienteJId")] SaidaCaixa saidaCaixa)
        {
            if (id != saidaCaixa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saidaCaixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaidaCaixaExists(saidaCaixa.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", saidaCaixa.ClienteId);
            return View(saidaCaixa);
        }
        // GET: SaidaCaixa/Edit/5
        public async Task<IActionResult> EditPJ(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaCaixa = await _context.SaidasCaixa.FindAsync(id);
            if (saidaCaixa == null)
            {
                return NotFound();
            }
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", saidaCaixa.ClienteId);
            return View(saidaCaixa);
        }

        // POST: SaidaCaixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPJ(int id, [Bind("Id,Valor,MetodoPagamento,Descricao,Data,Sangria,ClienteId,ClienteJId")] SaidaCaixa saidaCaixa)
        {
            if (id != saidaCaixa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saidaCaixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaidaCaixaExists(saidaCaixa.Id))
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
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", saidaCaixa.ClienteId);
            return View(saidaCaixa);
        }

        // GET: SaidaCaixa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaCaixa = await _context.SaidasCaixa
                .Include(s => s.PessoaFisica)
                .Include(s => s.PessoaJuridica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saidaCaixa == null)
            {
                return NotFound();
            }

            return View(saidaCaixa);
        }

        // POST: SaidaCaixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saidaCaixa = await _context.SaidasCaixa.FindAsync(id);
            if (saidaCaixa != null)
            {
                _context.SaidasCaixa.Remove(saidaCaixa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Relatorio()
        {
            var context = _context.SaidasCaixa.Include(e => e.PessoaFisica).Include(e => e.PessoaJuridica);
            List<SaidaCaixa> entrada = await context.ToListAsync();

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
            string cont = "Relatório de saída de valores do escritorio\n\n" + "Total de Clientes: " + entrada.Count + "\n\n";
            par.Add(cont);
            doc.Add(par);

            PdfPTable table = new PdfPTable(1);
            foreach (var i in entrada)
            {
                string sga;
                if (i.Sangria == true) sga = "sim";
                else sga = "não";
                if (i.ClienteId != null)
                {
                    table.AddCell(
                    "Cliente: " + i.PessoaFisica.Nome +
                    "\nValor: " + i.Valor +
                    "\nMétodo de Pagamento: " + i.MetodoPagamento +
                    "\nData: " + i.Data.ToLongDateString() +
                    "\nDescrição: " + i.Descricao +
                    "\nSangria: " + sga);
                }
                else
                {
                    table.AddCell(
                    "Cliente: " + i.PessoaJuridica.RazaoSocial +
                    "\nValor: " + i.Valor +
                    "\nMétodo de Pagamento: " + i.MetodoPagamento +
                    "\nData: " + i.Data.ToLongDateString() +
                    "\nDescrição: " + i.Descricao +
                    "\nSangria: " + sga);
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

        private bool SaidaCaixaExists(int id)
        {
            return _context.SaidasCaixa.Any(e => e.Id == id);
        }
    }
}
