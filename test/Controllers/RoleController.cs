using Microsoft.AspNetCore.Mvc;
using test.Service;

namespace test.Controllers
{
    [Authorize(Roles = "Master")]

    public class RoleController : Controller
    {
        private readonly RoleIS _role;
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;
        public RoleController(RoleIS role, Context context
            , UserManager<IdentityUser> userManager)
        {
            _role = role;
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _role.ListRole());
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleDto role)
        {
            if(ModelState.IsValid)
            {
                await _role.Create(role);

                return RedirectToAction("Index");
            }
            return View();
        }
        
        
    }
}
