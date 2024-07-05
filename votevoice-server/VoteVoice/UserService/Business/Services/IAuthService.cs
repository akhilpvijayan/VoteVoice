using UserService.Business.Services.Dto;

namespace UserService.Business.Services
{
    public interface IAuthService
    {
        Task<Tuple<string, string, long>> GenerateToken(string username, string password, bool isRefresh = false);
        Task<Tuple<string, string>> Refresh(TokenApiDto tokenApiDto);
    }
}
