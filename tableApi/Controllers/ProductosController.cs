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

    }
}
