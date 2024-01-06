using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{ 
    public class RevenueController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public RevenueController(UserManager<IdentityUser> UserManager)
        {
            _userManager = UserManager;
        }
        [Authorize(Roles = "Admin, Master")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
