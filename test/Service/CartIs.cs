namespace test.Service
{
    public interface CartIS
    {
        Task<IEnumerable<Cart>> YouCart(IdentityUser user);
        Task<IEnumerable<Cart>> AllCart();
        Task AddCart(IdentityUser user, Food food, int qul);
        Task<Cart> GetCartByCartId(int cartId);
    }
}
