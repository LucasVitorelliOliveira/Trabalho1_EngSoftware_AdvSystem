using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvSystem.Data;
using AdvSystem.Models;

namespace AdvSystem.Controllers
{
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
            if(cobranca.Parcela >= 1)
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

        private bool CobrancaExists(int id)
        {
            return _context.Cobrancas.Any(e => e.Id == id);
        }
    }
}
