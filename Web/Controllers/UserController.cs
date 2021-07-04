using Application.Common.Interface;
using Domain.Entities.Player;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Dtos;

namespace Web.Controllers
{
    [ApiController]
    [Route("[cotroller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
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
        public async Task<ActionResult<User>> GetUser(Guid id)
        {

        }
    }
}
