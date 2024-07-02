using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.Metrics;
using UserService.Business.Services;
using UserService.Business.Services.Dto;
using UserService.Caching;
using UserService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region properties
        private readonly IUserService _userService;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region constructor
        public UserController(IUserService userService, ICacheProvider cacheProvider)
        {
            this._userService = userService;
            this._cacheProvider = cacheProvider;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("{userid}")]
        public async Task<IActionResult> GetUser(long userId)
        {
            try
            {
                var user = await _userService.GetUser(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignUpUser([FromForm] SignUpUserDetailsDto userDetails)
        {
            try
            {
                if (userDetails != null)
                {
                    var result = await _userService.SignUpUser(userDetails);
                    if (result != null)
                    {
                        return Ok(new
                        {
                            Message = "User Creation Success.",
                            Token = result.Item1.ToString(),
                            RefreshToken = result.Item2.ToString(),
                            UserId = result.Item3
                        });
                    };
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("{userid}")]
        public async Task<IActionResult> UpdateUser([FromForm] SignUpUserDetailsDto userDetails, long userid)
        {
            try
            {
                var user = _userService.UpdateUser(userDetails, userid);
                if (user.Result != null)
                {
                    return Ok(user.Result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var result = await _userService.DeleteUser(userId);
                if(result)
                {
                    return Ok(new
                    {
                        Message = "User Deletion Success.",
                    });
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("country")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                if (!_cacheProvider.TryGetValue(CacheKeys.Country, out List<Countries> countries))
                {
                    countries = _userService.GetAllCountries();

                    var cacheEntryOption = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(2),
                        SlidingExpiration = TimeSpan.FromMinutes(2),
                        Size = 1024
                    };

                    _cacheProvider.Set(CacheKeys.Country, countries, cacheEntryOption);
                }
                if (countries != null)
                {
                    return Ok(countries);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("state/{countryId}")]
        public async Task<IActionResult> GetStates(long countryId)
        {
            return Ok(_userService.GetStates(countryId));
        }

        [HttpGet("duplicate/username/{username}")]
        public bool CheckDuplicateUserName(string username)
        {
            try
            {
                return _userService.CheckDuplicateUserName(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("duplicate/email/{email}")]
        public bool CheckDuplicateEmail(string email)
        {
            try
            {
                return _userService.CheckDuplicateEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
