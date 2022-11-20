using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using financeApp.Models;

namespace financeApp.Controllers
{
    public class EgresoesController : Controller
    {
        private readonly ModelContext _context;

        public EgresoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Egresoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Egresos.ToListAsync());
        }

        // GET: Egresoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Egresos == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egresos
                .FirstOrDefaultAsync(m => m.Idegreso == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // GET: Egresoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Egresoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idegreso,Montoegreso,Fechaegreso,Descripcionegreso")] Egreso egreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(egreso);
        }

        // GET: Egresoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Egresos == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egresos.FindAsync(id);
            if (egreso == null)
            {
                return NotFound();
            }
            return View(egreso);
        }

        // POST: Egresoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Idegreso,Montoegreso,Fechaegreso,Descripcionegreso")] Egreso egreso)
        {
            if (id != egreso.Idegreso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgresoExists(egreso.Idegreso))
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
            return View(egreso);
        }

        // GET: Egresoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Egresos == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egresos
                .FirstOrDefaultAsync(m => m.Idegreso == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // POST: Egresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Egresos == null)
            {
                return Problem("Entity set 'ModelContext.Egresos'  is null.");
            }
            var egreso = await _context.Egresos.FindAsync(id);
            if (egreso != null)
            {
                _context.Egresos.Remove(egreso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgresoExists(decimal id)
        {
          return _context.Egresos.Any(e => e.Idegreso == id);
        }
    }
}
