using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDespesas.Data;
using ProjetoDespesas.Models;

namespace ProjetoDespesas.Controllers
{
    public class SalarioController : Controller
    {
        private readonly DespesasContexto _context;

        public SalarioController(DespesasContexto context)
        {
            _context = context;
        }

        // GET: Salario
        public async Task<IActionResult> Index()
        {
            var despesasContexto = _context.Salarios.Include(s => s.Mes);
            return View(await despesasContexto.ToListAsync());
        }

        // GET: Salario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.Salarios
                .Include(s => s.Mes)
                .FirstOrDefaultAsync(m => m.SalarioId == id);
            if (salario == null)
            {
                return NotFound();
            }

            return View(salario);
        }

        // GET: Salario/Create
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome");
            return View();
        }

        // POST: Salario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalarioId,MesId,Valor")] Salario salario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", salario.MesId);
            return View(salario);
        }

        // GET: Salario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.Salarios.FindAsync(id);
            if (salario == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", salario.MesId);
            return View(salario);
        }

        // POST: Salario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalarioId,MesId,Valor")] Salario salario)
        {
            if (id != salario.SalarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalarioExists(salario.SalarioId))
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
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", salario.MesId);
            return View(salario);
        }

        // GET: Salario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.Salarios
                .Include(s => s.Mes)
                .FirstOrDefaultAsync(m => m.SalarioId == id);
            if (salario == null)
            {
                return NotFound();
            }

            return View(salario);
        }

        // POST: Salario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salario = await _context.Salarios.FindAsync(id);
            _context.Salarios.Remove(salario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalarioExists(int id)
        {
            return _context.Salarios.Any(e => e.SalarioId == id);
        }
    }
}
