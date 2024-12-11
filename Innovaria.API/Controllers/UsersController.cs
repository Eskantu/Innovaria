using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Innovaria.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetUsers();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post(User user)
        {
            if (user == null)
                return BadRequest("User cant be null");
            if (userRepository.AddUser(user))
                return Ok();
            else
                return BadRequest("error to create user");
        }

    }
}
