using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Reflection.PortableExecutable;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Innovaria.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ITokenService _tokenService;
        private IUserRepository _userRepository;
        public AuthenticationController(ITokenService tokenService, IUserRepository userRepository)
        {
            this._tokenService = tokenService;
            this._userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public string Login(User user)
        {
            User userInfo = _userRepository.GetUser(user.UserName);
            if (!string.IsNullOrEmpty(userInfo.UserName))
            {
                return _tokenService.CreateToken(userInfo);
            }
            throw new Exception("Wrong user or password");
        }

    }
}
