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
    public class OrdensController : Controller
    {
        private readonly ModelContext _context;

        public OrdensController(ModelContext context)
        {
            _context = context;
        }

        // GET: Ordens
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Ordens.Include(o => o.IdmesaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Ordens/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens
                .Include(o => o.IdmesaNavigation)
                .FirstOrDefaultAsync(m => m.Idorden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordens/Create
        public IActionResult Create()
        {
            ViewData["Idmesa"] = new SelectList(_context.Mesas, "Idmesa", "Idmesa");
            return View();
        }

        // POST: Ordens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idorden,Contenidoorden,Estadoorden,Total,Idmesa")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idmesa"] = new SelectList(_context.Mesas, "Idmesa", "Idmesa", orden.Idmesa);
            return View(orden);
        }

        // GET: Ordens/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["Idmesa"] = new SelectList(_context.Mesas, "Idmesa", "Idmesa", orden.Idmesa);
            return View(orden);
        }

        // POST: Ordens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Idorden,Contenidoorden,Estadoorden,Total,Idmesa")] Orden orden)
        {
            if (id != orden.Idorden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.Idorden))
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
            ViewData["Idmesa"] = new SelectList(_context.Mesas, "Idmesa", "Idmesa", orden.Idmesa);
            return View(orden);
        }

        // GET: Ordens/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens
                .Include(o => o.IdmesaNavigation)
                .FirstOrDefaultAsync(m => m.Idorden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Ordens == null)
            {
                return Problem("Entity set 'ModelContext.Ordens'  is null.");
            }
            var orden = await _context.Ordens.FindAsync(id);
            if (orden != null)
            {
                _context.Ordens.Remove(orden);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(decimal id)
        {
          return _context.Ordens.Any(e => e.Idorden == id);
        }




        public async Task<IActionResult> changeOrderOngoing(decimal id, Orden orden)
        {
            var context = new ModelContext();
            var result = context.Ordens.SingleOrDefault(b => b.Idorden == id);
            if (result != null)
            {
                result.Estadoorden = "en proceso";
                context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> changeOrderOngoing2(decimal id, Orden orden)
        {
            var context = new ModelContext();
            var result = context.Ordens.SingleOrDefault(b => b.Idorden == id);
            if (result != null)
            {
                result.Estadoorden = "despachado";
                context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> changeOrderOngoing3(decimal id, Orden orden)
        {
            var context = new ModelContext();
            var result = context.Ordens.SingleOrDefault(b => b.Idorden == id);
            if (result != null)
            {
                result.Estadoorden = "Terminado";
                context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }






















    }
}
