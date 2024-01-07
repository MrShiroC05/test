

namespace test.Service
{
    public interface FoodIS
    {
        Task<List<Food>> ListFood();
        Task<List<Category>> ListCategory();
        // Create
        Task CreateFood(Food food);
        Task CreateCate(Category category);
        Task<Food> SearchFood(int id);
        Task<Category> SearchCategory(int id);
        Task EditFood(Food food);
        Task EditeCate(Category cate);
        Task DeleteFood(int id);
        Task DeleteCate(int id);
    }
}
