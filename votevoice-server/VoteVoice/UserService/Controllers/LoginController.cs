using LazyCache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Business.Services;
using UserService.Business.Services.Dto;

namespace UserService.Controllers
{
    public class LoginController : Controller
    {
        #region properties
        private readonly IAuthService _authService;
        #endregion

        #region constructor
        public LoginController(IAuthService authService)
        {
            this._authService = authService;
        }
        #endregion

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModelDto loginModel)
        {
            try
            {
                var token = _authService.GenerateToken(loginModel.Username, loginModel.Password);
                return Ok(new { 
                    Token = token.Result.Item1,
                    RefreshToken = token.Result.Item2,
                    User = token.Result.Item3,
                    Message = "Login Success"
                });
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken(TokenApiDto tokenApiDto)
        {
            try
            {
                if (tokenApiDto != null)
                {
                    var tokens = await _authService.Refresh(tokenApiDto);
                    if (tokens != null)
                    {
                        return Ok(new TokenApiDto()
                        {
                            AccessToken = tokens.Item1,
                            RefreshToken = tokens.Item2,
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
    }
}
