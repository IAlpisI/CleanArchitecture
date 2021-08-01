using Application.Common.Interface;
using Application.Specification;
using Domain.Entities.Particapant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Web.Dtos;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserRepository userRepository, IUserService userService, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> CreateUser(UserRegisterDTO register)
        {
            try
            {
                User newUSer = await _userService.AddUserAsync(
                    register.UserName,
                    register.Password).ConfigureAwait(false);

                return newUSer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failder registering new user: {user}", register);
                return Conflict();
            }
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _userRepository.FirstAsync(new UserByIdWithRoles(id)).ConfigureAwait(false);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed fetch the user.");
                return StatusCode(500, "internal server error");
            }
        }
    }
}
