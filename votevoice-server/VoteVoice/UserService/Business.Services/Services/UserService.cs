using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UserService.Business.Services.Dto;
using UserService.Data;
using UserService.Helper;
using UserService.Models;

namespace UserService.Business.Services.Services
{
    public class UserService : IUserService
    {
        #region properties
        private readonly ILogger<UserService> _logger;
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        #endregion

        #region constructor
        public UserService(ILogger<UserService> logger, DataContext context, IAuthService authService)
        {
            this._logger = logger;
            this._context = context;
            this._authService = authService;
        }
        #endregion

        #region public functions

        public async Task<IEnumerable<UserDetailDto>> GetAllUsers()
        {
            var sqlQuery = $"Exec spGetUserDetails";
            return await this._context.UserDetailDto.FromSqlRaw(sqlQuery).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<UserDetailDto>> GetUser(long userId)
        {
            var sqlQuery = $"Exec spGetUserDetails {userId}";
            return await this._context.UserDetailDto.FromSqlRaw(sqlQuery).AsNoTracking().ToListAsync();
        }

        public async Task<Tuple<string, string, long>> SignUpUser(SignUpUserDetailsDto userDetails)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Users user = new Users();
                    user.Username = userDetails.Username;
                    user.Password = PasswordHasher.HashPassword(userDetails.Password);
                    user.Email = userDetails.Email;
                    user.RoleId = userDetails.RoleId;
                    user.LastLogin = DateTime.Now;
                    user.CreatedBy = 1;
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedBy = 1;
                    user.ModifiedDate = DateTime.Now;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    byte[] profileImage = null;
                    using (var ms = new MemoryStream())
                    {
                        if (userDetails.ProfileImage != null)
                        {
                            await userDetails.ProfileImage.CopyToAsync(ms);
                            profileImage = ms.ToArray();
                        }
                    }

                    UserDetails userDetail = new UserDetails();
                    userDetail.UserId = user.UserId;
                    userDetail.FirstName = userDetails.FirstName;
                    userDetail.LastName = userDetails.LastName;
                    userDetail.ProfileImage = profileImage;
                    userDetail.Gender = userDetails.Gender;
                    userDetail.UserBio = userDetails.UserBio;
                    userDetail.Region = userDetails.Region;
                    userDetail.CountryId = userDetails.CountryId;
                    userDetail.StateId = userDetails.StateId;
                    userDetail.Region = userDetails.Region;
                    userDetail.CreatedBy = user.UserId;
                    userDetail.CreatedDate = DateTime.Now;
                    userDetail.ModifiedBy = user.UserId;
                    userDetail.ModifiedDate = DateTime.Now;

                    _context.UserDetails.Add(userDetail);
                    await _context.SaveChangesAsync();

                    user.CreatedBy = user.UserId;
                    user.ModifiedBy = user.UserId;

                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return await this._authService.GenerateToken(userDetails.Username, userDetails.Password);

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        public async Task<bool> UpdateUser(SignUpUserDetailsDto userDetails, long userId)
        {
            try
            {
                var user = await this._context.UserDetails.FirstOrDefaultAsync(x => x.UserId == userId);
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.CountryId = userDetails.CountryId;
                user.StateId = userDetails.StateId;
                user.Region = userDetails.Region;
                user.UserBio = userDetails.UserBio;
                user.ModifiedBy = userId;
                user.ModifiedDate = DateTime.Now;

                byte[] profileImage = null;
                using (var ms = new MemoryStream())
                {
                    if (userDetails.ProfileImage != null)
                    {
                        await userDetails.ProfileImage.CopyToAsync(ms);
                        profileImage = ms.ToArray();
                    }
                }
                user.ProfileImage = profileImage;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUser(long userId)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = await _context.Users.FindAsync(userId);
                    if (user == null)
                    {
                        return false;
                    }

                    _context.Users.Remove(user);

                    var userDetail = await _context.UserDetails.FindAsync(userId);
                    if (userDetail == null)
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }

                    _context.UserDetails.Remove(userDetail);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        public List<Countries> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public List<States> GetStates(long countryId)
        {
            return _context.States.Where(state=> state.CountryId == countryId).ToList();
        }

        public bool CheckDuplicateUserName(string username)
        {
            var user = this._context.Users.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckDuplicateEmail(string email)
        {
            var user = this._context.Users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
