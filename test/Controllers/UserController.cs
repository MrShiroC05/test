using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [Authorize(Roles = "Admin, Master")]
    public class UserController : Controller
    {
        private readonly RoleIS _role;
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(Context context,
            RoleIS role,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _role = role;
            _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
            var list = await _context.Users.ToListAsync();
            return View(list);
        }
        [Authorize(Roles ="Master")]
        public IActionResult AddRoleToUser(string id)
        {
            ViewBag.Id = id;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(string role, string userId)
        {
            if(role != null && userId != null)
            {
                await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(userId), role);

                return RedirectToAction("Index");
            }
            ViewBag.Id = userId;

            return View();
        }
    }
}
