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
        public async Task<IActionResult> Create([Bind("Id,Valor,MetodoPagamento,Descricao,Data,Sangria,ClienteId,ClienteJId,UsuarioId")] SaidaCaixa saidaCaixa)
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
        public async Task<IActionResult> CreatePJ([Bind("Id,Valor,MetodoPagamento,Descricao,Data,Sangria,ClienteId,ClienteJId,UsuarioId")] SaidaCaixa saidaCaixa)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,MetodoPagamento,Descricao,Data,Sangria,ClienteId,ClienteJId,UsuarioId")] SaidaCaixa saidaCaixa)
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
        public async Task<IActionResult> EditPJ(int id, [Bind("Id,Valor,MetodoPagamento,Descricao,Data,Sangria,ClienteId,ClienteJId,UsuarioId")] SaidaCaixa saidaCaixa)
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

        private bool SaidaCaixaExists(int id)
        {
            return _context.SaidasCaixa.Any(e => e.Id == id);
        }
    }
}
