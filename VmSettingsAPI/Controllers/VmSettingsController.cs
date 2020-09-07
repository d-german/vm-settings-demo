using System.Linq;
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
        private readonly IVmSettingValidatorService _vmSettingValidator;

        public VmSettingsController(IVmSettingService vmSettingService, IVmSettingValidatorService vmSettingValidator)
        {
            _vmSettingService = vmSettingService;
            _vmSettingValidator = vmSettingValidator;
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
            var errors = _vmSettingValidator.Validate(value);
            if (errors.Any()) return StatusCode(400, errors);
            _vmSettingService.Write(value);
            return value;
        }
    }
}
