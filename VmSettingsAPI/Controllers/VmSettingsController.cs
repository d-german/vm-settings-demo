using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VmSettingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VmSettingsController : ControllerBase
    {
        // GET: api/<VmSettingsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<VmSettingsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
