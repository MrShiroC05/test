using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class FoodController : Controller
    {
        private readonly FoodIS _foodSv;
        private readonly CartIS _cart;
        private readonly UserManager<IdentityUser> _userManager;
        public FoodController(
            FoodIS foodSv,
            UserManager<IdentityUser> userManager,
            CartIS cart
            )
        {
            _foodSv = foodSv;
            _userManager = userManager;
            _cart = cart;
        }
        public async Task<IActionResult> Index(int id = 0)
        {
            var food = await _foodSv.ListFood();
            var category = await _foodSv.ListCategory();
            if (id != 0)
            {
                var categoryFood = food.FindAll(x => x.CategoryId == id);
                food = categoryFood;
            }
            return View(new { category, food });
        }
        // Create
        public IActionResult CreateFood()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFood(Food food)
        {
            if (ModelState.IsValid)
            {
                await _foodSv.CreateFood(food);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await _foodSv.CreateCate(category);
                return RedirectToAction("Index");
            }
                
            return View();
        }

        // Edit
        public async Task<IActionResult> EditFood(int id)
        {
            return View(await _foodSv.SearchFood(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditFood(Food food)
        {
           if(ModelState.IsValid)
            {
                await _foodSv.EditFood(food);
                return RedirectToAction("Index");
            }
            return View(await _foodSv.SearchFood(food.Id));
        }
        public async Task<IActionResult> DeleteFood(int id)
        {
            await _foodSv.DeleteFood(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeletCategory(int id)
        {
            await _foodSv.DeleteCate(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> InfoFood(int id)
        {
            return View(await _foodSv.SearchFood(id));
        }

        public async Task<IActionResult> AddCart(int id, int qul = 1)
        {
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            var food = await _foodSv.SearchFood(id);

            await _cart.AddCart(user,food,qul);
            return RedirectToAction("Index");
        }
    }
}
