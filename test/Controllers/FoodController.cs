using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
