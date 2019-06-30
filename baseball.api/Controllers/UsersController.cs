using System.Linq;
using Baseball.Controllers.Dto;
using Baseball.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Baseball.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(User userDto)
        {
            var user = _userService.Create(userDto.ToModel(), userDto.Password);

            // TODO real error messages
            if (user == null)
            {
                return Conflict("user already exists");
            }

            return Ok("user created");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users.Select(Dto.User.ToDto));
        }
    }
}