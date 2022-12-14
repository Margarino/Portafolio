using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kitchenApp.Models;

namespace kitchenApp.Controllers
{
    public class PlatoesController : Controller
    {
        private readonly ModelContext _context;

        public PlatoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Platoes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Platos.Include(p => p.IdrecetaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Platoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .Include(p => p.IdrecetaNavigation)
                .FirstOrDefaultAsync(m => m.Idplato == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // GET: Platoes/Create
        public IActionResult Create()
        {
            ViewData["Idreceta"] = new SelectList(_context.Receta, "Idreceta", "Idreceta");
            return View();
        }

        // POST: Platoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idplato,Idreceta,Nombreplato,Valorplato,DescripcionPlato")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idreceta"] = new SelectList(_context.Receta, "Idreceta", "Idreceta", plato.Idreceta);
            return View(plato);
        }

        // GET: Platoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }
            ViewData["Idreceta"] = new SelectList(_context.Receta, "Idreceta", "Idreceta", plato.Idreceta);
            return View(plato);
        }

        // POST: Platoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Idplato,Idreceta,Nombreplato,Valorplato,DescripcionPlato")] Plato plato)
        {
            if (id != plato.Idplato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoExists(plato.Idplato))
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
            ViewData["Idreceta"] = new SelectList(_context.Receta, "Idreceta", "Idreceta", plato.Idreceta);
            return View(plato);
        }

        // GET: Platoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .Include(p => p.IdrecetaNavigation)
                .FirstOrDefaultAsync(m => m.Idplato == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // POST: Platoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Platos == null)
            {
                return Problem("Entity set 'ModelContext.Platos'  is null.");
            }
            var plato = await _context.Platos.FindAsync(id);
            if (plato != null)
            {
                _context.Platos.Remove(plato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatoExists(decimal id)
        {
          return _context.Platos.Any(e => e.Idplato == id);
        }
    }
}
