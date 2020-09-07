using Microsoft.AspNetCore.Mvc;
using VmSettingsAPI.Models;
using VmSettingsAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VmSettingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VmSettingsController : ControllerBase
    {
        private readonly IVmSettingService _vmSettingService;

        public VmSettingsController(IVmSettingService vmSettingService)
        {
            _vmSettingService = vmSettingService;
        }

        // GET: api/<VmSettingsController>
        [HttpGet]
        public ActionResult<VmSetting> Get()
        {
            return _vmSettingService.Load();
        }

        // PUT api/<VmSettingsController>
        [HttpPut]
        public ActionResult<VmSetting> Post([FromBody] VmSetting value)
        {
            _vmSettingService.Write(value);
            return value;
        }
    }
}
