using Innovaria.COMMON.Entities;
using Innovaria.DAL.Repositories.Sensores;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Innovaria.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SensoresController : ControllerBase
    {
        private readonly ISensorRepository sensorRepository;
        public SensoresController(ISensorRepository sensorRepository)
        {
            this.sensorRepository = sensorRepository;
            
        }

        // GET api/<SensoresController>/5
        [HttpGet("{page}")]
        public List<Sensor> Get(int page=1)
        {
            return sensorRepository.GetSensorsByPage(page);
        }

        // POST api/<SensoresController>
        [HttpPost]
        public IActionResult Post([FromBody] string sensorName)
        {
            if (sensorRepository.AddSensor(sensorName))
            {
                return Ok();
            }
            else
                return BadRequest("Error to create sensor");


        }
    }
}
