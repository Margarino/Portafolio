using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudAdmin.Models;

namespace crudAdmin.Controllers
{
    public class Empleado2Controller : Controller
    {
        private readonly ModelContext _context;

        public Empleado2Controller(ModelContext context)
        {
            _context = context;
        }

        // GET: Empleado2
        public async Task<IActionResult> Index()
        {
              return View(await _context.Empleado2s.ToListAsync());
        }

        // GET: Empleado2/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Empleado2s == null)
            {
                return NotFound();
            }

            var empleado2 = await _context.Empleado2s
                .FirstOrDefaultAsync(m => m.Rut == id);
            if (empleado2 == null)
            {
                return NotFound();
            }

            return View(empleado2);
        }

        // GET: Empleado2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleado2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Rut,IdCargo,DescripcionCargo")] Empleado2 empleado2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado2);
        }

        // GET: Empleado2/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Empleado2s == null)
            {
                return NotFound();
            }

            var empleado2 = await _context.Empleado2s.FindAsync(id);
            if (empleado2 == null)
            {
                return NotFound();
            }
            return View(empleado2);
        }

        // POST: Empleado2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nombre,Rut,IdCargo,DescripcionCargo")] Empleado2 empleado2)
        {
            if (id != empleado2.Rut)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Empleado2Exists(empleado2.Rut))
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
            return View(empleado2);
        }

        // GET: Empleado2/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Empleado2s == null)
            {
                return NotFound();
            }

            var empleado2 = await _context.Empleado2s
                .FirstOrDefaultAsync(m => m.Rut == id);
            if (empleado2 == null)
            {
                return NotFound();
            }

            return View(empleado2);
        }

        // POST: Empleado2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Empleado2s == null)
            {
                return Problem("Entity set 'ModelContext.Empleado2s'  is null.");
            }
            var empleado2 = await _context.Empleado2s.FindAsync(id);
            if (empleado2 != null)
            {
                _context.Empleado2s.Remove(empleado2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Empleado2Exists(string id)
        {
          return _context.Empleado2s.Any(e => e.Rut == id);
        }
    }
}
