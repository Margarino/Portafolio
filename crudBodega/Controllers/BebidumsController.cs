using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudBodega.Models;

namespace crudBodega.Controllers
{
    public class BebidumsController : Controller
    {
        private readonly ModelContext _context;

        public BebidumsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Bebidums
        public async Task<IActionResult> Index()
        {
              return View(await _context.Bebida.ToListAsync());
        }

        // GET: Bebidums/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebidum = await _context.Bebida
                .FirstOrDefaultAsync(m => m.Idbebida == id);
            if (bebidum == null)
            {
                return NotFound();
            }

            return View(bebidum);
        }

        // GET: Bebidums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bebidums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idbebida,Nombrebebida,Valorbebida,Cantidadbebida")] Bebidum bebidum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bebidum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bebidum);
        }

        // GET: Bebidums/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebidum = await _context.Bebida.FindAsync(id);
            if (bebidum == null)
            {
                return NotFound();
            }
            return View(bebidum);
        }

        // POST: Bebidums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Idbebida,Nombrebebida,Valorbebida,Cantidadbebida")] Bebidum bebidum)
        {
            if (id != bebidum.Idbebida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bebidum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BebidumExists(bebidum.Idbebida))
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
            return View(bebidum);
        }

        // GET: Bebidums/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebidum = await _context.Bebida
                .FirstOrDefaultAsync(m => m.Idbebida == id);
            if (bebidum == null)
            {
                return NotFound();
            }

            return View(bebidum);
        }

        // POST: Bebidums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Bebida == null)
            {
                return Problem("Entity set 'ModelContext.Bebida'  is null.");
            }
            var bebidum = await _context.Bebida.FindAsync(id);
            if (bebidum != null)
            {
                _context.Bebida.Remove(bebidum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BebidumExists(decimal id)
        {
          return _context.Bebida.Any(e => e.Idbebida == id);
        }
    }
}
