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
            return View(await _context.Productos.ToListAsync());
        }
        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }


        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Idproducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
    }
}
