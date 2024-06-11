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

namespace AdvSystem.Controllers
{
    [UsuarioLogado]
    public class PessoaJuridicaController : Controller
    {
        private readonly Context _context;

        public PessoaJuridicaController(Context context)
        {
            _context = context;
        }

        // GET: PessoaJuridica
        public async Task<IActionResult> Index()
        {
            var context = _context.PessoasJuridicas.Include(p => p.RepresentanteLegal);
            return View(await context.ToListAsync());
        }

        // GET: PessoaJuridica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoasJuridicas
                .Include(p => p.RepresentanteLegal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        // GET: PessoaJuridica/Create
        public IActionResult Create()
        {
            ViewData["RepresentanteLegalId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome");
            return View();
        }

        // POST: PessoaJuridica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazaoSocial,NomeFantasia,Cnpj,InscricaoEstadual,Uf,Cidade,Rua,Numero,Bairro,RepresentanteLegalId")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaJuridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RepresentanteLegalId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", pessoaJuridica.RepresentanteLegalId);
            return View(pessoaJuridica);
        }

        [EstAdvLogado]
        // GET: PessoaJuridica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }
            ViewData["RepresentanteLegalId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", pessoaJuridica.RepresentanteLegalId);
            return View(pessoaJuridica);
        }

        [EstAdvLogado]
        // POST: PessoaJuridica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RazaoSocial,NomeFantasia,Cnpj,InscricaoEstadual,Uf,Cidade,Rua,Numero,Bairro,RepresentanteLegalId")] PessoaJuridica pessoaJuridica)
        {
            if (id != pessoaJuridica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaJuridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaJuridicaExists(pessoaJuridica.Id))
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
            ViewData["RepresentanteLegalId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", pessoaJuridica.RepresentanteLegalId);
            return View(pessoaJuridica);
        }

        [EstAdvLogado]
        // GET: PessoaJuridica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoasJuridicas
                .Include(p => p.RepresentanteLegal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        [EstAdvLogado]
        // POST: PessoaJuridica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
            if (pessoaJuridica != null)
            {
                _context.PessoasJuridicas.Remove(pessoaJuridica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaJuridicaExists(int id)
        {
            return _context.PessoasJuridicas.Any(e => e.Id == id);
        }
    }
}
