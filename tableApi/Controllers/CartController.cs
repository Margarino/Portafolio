
using Microsoft.AspNetCore.Mvc;
using tableApi.Infrastructure;
using tableApi.Models;
using tableApi.Models.ViewModels;
using tableApi.Controllers;
namespace tableApi.Controllers
{
    public class CartController : Controller
    {
        private readonly ModelContext _context;

        public CartController(ModelContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return View(cartVM);
        }

        public async Task<IActionResult> AddPlato(string id)
        {


            Plato plato = await _context.Platos.FindAsync(decimal.Parse(id.ToString()));

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.ProductId == parseo(id)).FirstOrDefault();

            if (cartItem == null)
            {

                cart.Add(new CartItem(plato));

            }
            else
            {
                cartItem.Quantity += 1;
            }




            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "El Producto ha sido agregado";
            return Redirect(Request.Headers["Referer"].ToString());
        }


        public async Task<IActionResult> AddBebida(string id)
        {


            Bebidum bebida = await _context.Bebida.FindAsync(decimal.Parse(id.ToString()));

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.ProductId == parseo(id)).FirstOrDefault();

            if (cartItem == null)
            {

                cart.Add(new CartItem(bebida));

            }
            else
            {
                cartItem.Quantity += 1;
            }




            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "El Producto ha sido agregado";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(string id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
      
            CartItem cartItem = cart.Where(c => c.ProductId.Value == parseo(id)).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == parseo(id));
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "El producto ha sido removido";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(string id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ProductId == parseo(id));

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "El producto ha sido removido";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }

        public int parseo(string id)
        {
            int id2;
            string id3 = id.Trim(new Char[] { '0', ',' });

            Int32.TryParse(id3, out id2);
            return id2;
        }



    }
}