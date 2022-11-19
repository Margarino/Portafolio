using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tableApi.Models;
namespace tableApi.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ModelContext _context;

        public ProductosController(ModelContext context)
        {
            _context = context;
        }
        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Platos.ToListAsync());
        }
        // GET: Productos/Details/5
        public ActionResult AgregarCarrito(int id)
        {
            return View();
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> AgregarCarrito(decimal? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var producto = await _context.Platos
                .FirstOrDefaultAsync(m => m.Idplato == id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }
        // GET: Productoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idproducto,Descripcionproducto,Valorproducto")] Plato platos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platos);
        }

    }
}
