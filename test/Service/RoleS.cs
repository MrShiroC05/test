
using Microsoft.AspNetCore.Identity;
using test.Models;

namespace test.Service
{
    public class RoleS : RoleIS
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RoleS(RoleManager<IdentityRole> roleManager,
        UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task Create(RoleDto roleDto)
        {
            var role = new IdentityRole
            {
                Name = roleDto.Name,
                NormalizedName = _roleManager.NormalizeKey(roleDto.Name),
            };
            await _roleManager.CreateAsync(role);
        }

        public Task Delete(RoleDto role)
        {
            throw new NotImplementedException();
        }

        public Task Edite(RoleDto role)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IdentityRole>> ListRole()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task AddRole(IdentityUser user, IdentityRole role)
        {
            // ตรวจสอบว่าผู้ใช้มี Role นี้อยู่แล้วหรือไม่
            //IsInRole(userId, roleName)
            var a = user.Id;
            if (!await _userManager.IsInRoleAsync(user, role.Name))
            {
                // เพิ่ม Role ให้กับผู้ใช้
                _userManager.AddToRoleAsync(user, role.Name);
            }
        }
    }
}
