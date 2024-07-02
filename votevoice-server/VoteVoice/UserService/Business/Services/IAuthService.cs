namespace UserService.Business.Services
{
    public interface IAuthService
    {
        Task<Tuple<string, string, long>> GenerateToken(string username, string password, bool isRefresh = false);
    }
}
