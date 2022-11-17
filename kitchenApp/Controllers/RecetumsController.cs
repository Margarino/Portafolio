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
    public class RecetumsController : Controller
    {
        private readonly ModelContext _context;

        public RecetumsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Recetums
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Receta.Include(r => r.IdingredienteNavigation).Include(r => r.IdproductoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Recetums/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Receta == null)
            {
                return NotFound();
            }

            var recetum = await _context.Receta
                .Include(r => r.IdingredienteNavigation)
                .Include(r => r.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.Idreceta == id);
            if (recetum == null)
            {
                return NotFound();
            }

            return View(recetum);
        }

        // GET: Recetums/Create
        public IActionResult Create()
        {
            ViewData["Idingrediente"] = new SelectList(_context.Ingredientes, "Idingrediente", "Idingrediente");
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto");
            return View();
        }

        // POST: Recetums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idreceta,Idingrediente,Idproducto")] Recetum recetum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recetum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idingrediente"] = new SelectList(_context.Ingredientes, "Idingrediente", "Idingrediente", recetum.Idingrediente);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", recetum.Idproducto);
            return View(recetum);
        }

        // GET: Recetums/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Receta == null)
            {
                return NotFound();
            }

            var recetum = await _context.Receta.FindAsync(id);
            if (recetum == null)
            {
                return NotFound();
            }
            ViewData["Idingrediente"] = new SelectList(_context.Ingredientes, "Idingrediente", "Idingrediente", recetum.Idingrediente);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", recetum.Idproducto);
            return View(recetum);
        }

        // POST: Recetums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Idreceta,Idingrediente,Idproducto")] Recetum recetum)
        {
            if (id != recetum.Idreceta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recetum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecetumExists(recetum.Idreceta))
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
            ViewData["Idingrediente"] = new SelectList(_context.Ingredientes, "Idingrediente", "Idingrediente", recetum.Idingrediente);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", recetum.Idproducto);
            return View(recetum);
        }

        // GET: Recetums/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Receta == null)
            {
                return NotFound();
            }

            var recetum = await _context.Receta
                .Include(r => r.IdingredienteNavigation)
                .Include(r => r.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.Idreceta == id);
            if (recetum == null)
            {
                return NotFound();
            }

            return View(recetum);
        }

        // POST: Recetums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Receta == null)
            {
                return Problem("Entity set 'ModelContext.Receta'  is null.");
            }
            var recetum = await _context.Receta.FindAsync(id);
            if (recetum != null)
            {
                _context.Receta.Remove(recetum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetumExists(decimal id)
        {
          return _context.Receta.Any(e => e.Idreceta == id);
        }
    }
}
