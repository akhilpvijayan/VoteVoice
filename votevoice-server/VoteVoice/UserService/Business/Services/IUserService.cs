using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UserService.Models;
using UserService.Business.Services.Dto;

namespace UserService.Business.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetailDto>> GetAllUsers();
        Task<UserDetailDto> GetUser(long userId);
        Task<Tuple<string, string, long>> SignUpUser(SignUpUserDetailsDto userDetails);
        Task<bool> UpdateUser(SignUpUserDetailsDto userDetails, long userId);
        Task<bool> DeleteUser(long userId);
        List<Countries> GetAllCountries();
        List<States> GetStates(long countryId);
        bool CheckDuplicateUserName(string username);
        bool CheckDuplicateEmail(string email);
    }
}
