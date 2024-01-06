namespace test.Service
{
    public interface RoleIS
    {
        Task<List<IdentityRole>> ListRole();
        Task  Create(RoleDto role);
        Task Delete(RoleDto role);
        Task Edite(RoleDto role);
    }
}
