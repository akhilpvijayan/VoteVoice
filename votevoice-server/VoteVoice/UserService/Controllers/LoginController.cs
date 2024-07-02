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
                return Ok(new { Token = token });
            }
            catch
            {
                return View();
            }
        }
    }
}
