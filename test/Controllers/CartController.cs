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
        public async Task<IActionResult> Table()
        {
            var table = await _context.TableRevenue.ToListAsync();

            return View(table);
        }
    }
}
