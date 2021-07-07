using Application.Common.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Dtos;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [Route("token")]
        [HttpPost]
        public async Task<ActionResult> GetToken(UserLoginDTO userLogin)
        {
            string accessTokesn = await _tokenService.GetAccessTokenAsync(
                userLogin.UserName,
                userLogin.Password);

            if(string.IsNullOrEmpty(accessTokesn))
            {
                return Forbid();
            }

            return Ok(new { token = accessTokesn });
        }
    }
}
