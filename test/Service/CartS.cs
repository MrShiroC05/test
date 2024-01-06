

namespace test.Service
{
    public class CartS : CartIS
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CartS(Context context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task AddCart(IdentityUser user, Food food, int qul)
        {
            Cart cart = new()
            {
                IdFood = food.Id,
                IdUser = user.Id,
                Name = food.Name,
                ExtendCart = new()
                {
                    Price = food.ExtendFood.Price,
                    Qut = qul
                },

            };
            var cheak = await _context.Cart.ToListAsync();
            var result = cheak.Find(p=> p.IdFood == cart.IdFood && p.IdUser == user.Id);
            // เช็คว่ามีของคนนี้ยัง
            if (result != null)
            {
                result.ExtendCart.Qut += qul;
                _context.Cart.Update(result);
                await _context.SaveChangesAsync();
                cart =  result;
            }
            else
            {
                await _context.Cart.AddAsync(cart);
                await _context.SaveChangesAsync();
                cart = await _context.Cart.OrderBy(p => p.Id).LastAsync();
            }
            food.ExtendFood.Qut -= qul;

            TableRevenue table = new()
            {
                UserId = user.Id,
                CartId = cart.Id,
            };
           
            // เช็คว่ามีตารางนี้อยู่ไหม
            var allTable = _context.TableRevenue.ToList();
            var resulTable = allTable.Find(p=> p.UserId == table.UserId && p.CartId == table.CartId);
            if(resulTable == null)
            {
                _context.TableRevenue.Add(table);
                _context.Food.Update(food);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cart>> AllCart() => await _context.Cart.ToListAsync();

        public async Task<IEnumerable<Cart>> YouCart(IdentityUser user)
        {
            var all = await _context.Cart.ToListAsync();
            return all.FindAll(p => p.IdUser == user.Id);
        }
        public async Task<Cart> GetCartByCartId(int cartId)
        {
            var all = await _context.Cart.ToListAsync();
            var result = all.Find(p => p.Id == cartId);
            return result;
        }
    }
}
