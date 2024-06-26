﻿using System;
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
    [EstAdvLogado]
    public class GerenciaProcessosController : Controller
    {
        private readonly Context _context;

        public GerenciaProcessosController(Context context)
        {
            _context = context;
        }

        // GET: GerenciaProcessos
        public async Task<IActionResult> Index()
        {
            var context = _context.GereciamentoProcessos.Include(g => g.PessoaFisica).Include(g => g.PessoaJuridica);
            return View(await context.ToListAsync());
        }

        public IActionResult EscolherPessoa()
        {
            return View();
        }

        // GET: GerenciaProcessos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenciaProcesso = await _context.GereciamentoProcessos
                .Include(g => g.PessoaFisica)
                .Include(g => g.PessoaJuridica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerenciaProcesso == null)
            {
                return NotFound();
            }

            return View(gerenciaProcesso);
        }

        // GET: GerenciaProcessos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome");
            return View();
        }

        // POST: GerenciaProcessos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroProcesso,Descricao,Movimentacoes,ClienteId,ClienteJId")] GerenciaProcesso gerenciaProcesso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerenciaProcesso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", gerenciaProcesso.ClienteId);
            return View(gerenciaProcesso);
        }

        // GET: GerenciaProcessos/Create
        public IActionResult CreatePJ()
        {
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial");
            return View();
        }

        // POST: GerenciaProcessos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePJ([Bind("Id,NumeroProcesso,Descricao,Movimentacoes,ClienteId,ClienteJId")] GerenciaProcesso gerenciaProcesso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerenciaProcesso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", gerenciaProcesso.ClienteJId);
            return View(gerenciaProcesso);
        }

        // GET: GerenciaProcessos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenciaProcesso = await _context.GereciamentoProcessos.FindAsync(id);
            if (gerenciaProcesso == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", gerenciaProcesso.ClienteId);
            return View(gerenciaProcesso);
        }

        // POST: GerenciaProcessos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroProcesso,Descricao,Movimentacoes,ClienteId,ClienteJId")] GerenciaProcesso gerenciaProcesso)
        {
            if (id != gerenciaProcesso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerenciaProcesso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerenciaProcessoExists(gerenciaProcesso.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.PessoasFisicas, "Id", "Nome", gerenciaProcesso.ClienteId);
            return View(gerenciaProcesso);
        }

        public async Task<IActionResult> EditPJ(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenciaProcesso = await _context.GereciamentoProcessos.FindAsync(id);
            if (gerenciaProcesso == null)
            {
                return NotFound();
            }
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", gerenciaProcesso.ClienteJId);
            return View(gerenciaProcesso);
        }

        // POST: GerenciaProcessos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPJ(int id, [Bind("Id,NumeroProcesso,Descricao,Movimentacoes,ClienteId,ClienteJId")] GerenciaProcesso gerenciaProcesso)
        {
            if (id != gerenciaProcesso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerenciaProcesso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerenciaProcessoExists(gerenciaProcesso.Id))
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
            ViewData["ClienteJId"] = new SelectList(_context.PessoasJuridicas, "Id", "RazaoSocial", gerenciaProcesso.ClienteJId);
            return View(gerenciaProcesso);
        }

        // GET: GerenciaProcessos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenciaProcesso = await _context.GereciamentoProcessos
                .Include(g => g.PessoaFisica)
                .Include(g => g.PessoaJuridica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerenciaProcesso == null)
            {
                return NotFound();
            }

            return View(gerenciaProcesso);
        }

        // POST: GerenciaProcessos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerenciaProcesso = await _context.GereciamentoProcessos.FindAsync(id);
            if (gerenciaProcesso != null)
            {
                _context.GereciamentoProcessos.Remove(gerenciaProcesso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerenciaProcessoExists(int id)
        {
            return _context.GereciamentoProcessos.Any(e => e.Id == id);
        }
    }
}
