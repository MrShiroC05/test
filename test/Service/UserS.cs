
namespace test.Service
{
    public class UserS : UserIS
    {
        private readonly Context _context;
        public UserS(Context context)
        {

            _context = context;

        }
        public async Task<string> GetUsernameByID(string id)
        {
            var list = await _context.Users.ToListAsync();
            var result = list.Find(p => p.Id == id);

            return result.UserName;
        }
    }
}
