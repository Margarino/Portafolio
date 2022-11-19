using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using tableApi.Models;

namespace tableApi.Infrastructure.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ModelContext _context;

        public CategoriesViewComponent(ModelContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}
