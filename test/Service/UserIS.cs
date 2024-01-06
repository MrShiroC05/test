namespace test.Service
{
    public interface UserIS
    {
        Task<string> GetUsernameByID(string id);
    }
}
