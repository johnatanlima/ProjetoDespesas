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
    public class TipoDespesaController : Controller
    {
        private readonly DespesasContexto _context;

        public TipoDespesaController(DespesasContexto context)
        {
            _context = context;
        }

        // GET: TipoDespesa
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDespesas.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if(!String.IsNullOrEmpty(txtProcurar))
                return View(
                    await _context.TipoDespesas.Where(td => td.Nome.ToUpper()
                        .Contains(txtProcurar.ToUpper())
                    ).ToListAsync()
                );
            
            return View( await _context.TipoDespesas.ToListAsync());
        }

        public async Task<JsonResult> verificaDespesa(string nome){
            if (await _context.TipoDespesas.AnyAsync(td => td.Nome.ToUpper() == nome.ToUpper()))
                return Json("Esse tipo de despesa já existe!");

            return Json(true);
        }

        /*
      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDespesa = await _context.TipoDespesas
                .FirstOrDefaultAsync(m => m.TipoDespesaId == id);
            if (tipoDespesa == null)
            {
                return NotFound();
            }

            return View(tipoDespesa);
        }
        */

        // GET: TipoDespesa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDespesaId,Nome")] TipoDespesa tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = tipoDespesa.Nome + " foi cadastrado com sucesso"; //

                _context.Add(tipoDespesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesa);
        }

        // GET: TipoDespesa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDespesa = await _context.TipoDespesas.FindAsync(id);
            if (tipoDespesa == null)
            {
                return NotFound();
            }
            return View(tipoDespesa);
        }

        // POST: TipoDespesa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDespesaId,Nome")] TipoDespesa tipoDespesa)
        {
            if (id != tipoDespesa.TipoDespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = tipoDespesa.Nome + " foi atualizado com sucesso"; //

                    _context.Update(tipoDespesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDespesaExists(tipoDespesa.TipoDespesaId))
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
            return View(tipoDespesa);
        }
/* 
        // GET: TipoDespesa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDespesa = await _context.TipoDespesas
                .FirstOrDefaultAsync(m => m.TipoDespesaId == id);
            if (tipoDespesa == null)
            {
                return NotFound();
            }

            return View(tipoDespesa);
        } */

        // POST: TipoDespesa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(int id)
        {
            var tipoDespesa = await _context.TipoDespesas.FindAsync(id);
            
            TempData["Confirmacao"] = tipoDespesa.Nome + " foi excluido com sucesso";

            _context.TipoDespesas.Remove(tipoDespesa);
            await _context.SaveChangesAsync();
            return Json(tipoDespesa.Nome + " excluído com sucesso");
        }

        private bool TipoDespesaExists(int id)
        {
            return _context.TipoDespesas.Any(e => e.TipoDespesaId == id);
        }
    }
}
