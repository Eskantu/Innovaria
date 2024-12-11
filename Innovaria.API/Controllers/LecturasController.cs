using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Innovaria.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LecturasController : ControllerBase
    {
        private readonly ILecturasRepository lecturasRepository;
        public LecturasController(ILecturasRepository lecturasRepository)
        {
            this.lecturasRepository = lecturasRepository;   
        }

        // GET api/<LecturasController>/5
        [HttpGet("{page}")]
        public List<Lecturas> Get(int page=1)
        {
            return lecturasRepository.GetLecturasByPage(page);
        }

        // POST api/<LecturasController>
        [HttpPost]
        public IActionResult Post([FromBody] Lecturas value)
        {
            if (lecturasRepository.AddLectura(value))
                return Ok();
            else
                return BadRequest("Error when create a lectura");
        }
    }
}
