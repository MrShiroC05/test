
using test.Models;

namespace test.Service
{
    // Category และ food รวบเป็นอันเดียวกัน
    public class FoodS : FoodIS
    {
        public FoodS(Context context)
        {
            _context = context;
        }
        private readonly Context _context;
        public async Task<List<Food>> ListFood() => await _context.Food.ToListAsync();
        public async Task<List<Category>> ListCategory() => await _context.Category.ToListAsync();
        public async Task CreateFood(Food food)
        {
            await _context.Food.AddAsync(food);
            await _context.SaveChangesAsync();
        }
        public async Task CreateCate(Category category )
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Food> SearchFood(int id) => await _context.Food.FindAsync(id);
        public async Task<Category> SearchCategory(int id) => await _context.Category.FindAsync(id);

        public async Task EditFood(Food food)
        {
            _context.Update(food);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFood(int id)
        {
            var delete =  await SearchFood(id);
            if (delete != null)
            {
                _context.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCate(int id)
        {
            var delete = await SearchCategory(id);
            _context.Remove(delete);
            var foodFC = await _context.Food.ToListAsync();

            // เช็คว่ามีอาหารในหมวดนี้ไหม ถ้ามี ลบ มัน
            foodFC.ForEach(food =>
            {
                if (food.CategoryId == id)
                {
                    _context.Remove(food);
                }
            });
            await _context.SaveChangesAsync();
        }
    }
}
