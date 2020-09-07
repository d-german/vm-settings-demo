using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VmSettingsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VmSettingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VmSettingsController : ControllerBase
    {
        // GET: api/<VmSettingsController>
        [HttpGet]
        public ActionResult<VmSetting> Get()
        {
            return new VmSetting();
        }

        // PUT api/<VmSettingsController>
        [HttpPut]
        public ActionResult<VmSetting> Post([FromBody] VmSetting value)
        {
            return value;
        }



    }
}
