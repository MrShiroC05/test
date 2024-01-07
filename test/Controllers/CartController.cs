using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class CartController : Controller
    {
        private readonly Context _context;
        private readonly CartIS _cart;
        private readonly UserManager<IdentityUser> _userManager;
        public CartController(CartIS cart, UserManager<IdentityUser> userManager, Context context)
        {
            _cart = cart;
            _userManager = userManager;
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            
            return View(await _cart.YouCart(user));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Table(int id = 0)
        {
            var table = await _context.TableRevenue.ToListAsync();

            if(id != 0)
            {
                // หา cart จาก food's id
                var allCart = await _context.Cart.ToListAsync();
                var result_1 = allCart.FindAll(x => x.IdFood == id);


                var result_2 = new List<TableRevenue>();
                table.ForEach(table =>
                {
                    var foundItem = result_1.Find(cart => table.CartId == cart.Id);
                    if (foundItem != null)
                    {
                        result_2.Add(table);
                    }
                });
                table = result_2;
            }
            return View(table);
        }
        public async Task<IActionResult> Cancel(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            await _cart.Cencel(cart, user);

            return RedirectToAction("Index");
        }
    }
}
