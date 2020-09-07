using System.Collections.Generic;
using VmSettingsAPI.Models;

namespace VmSettingsAPI.Services
{
    public interface IVmSettingValidatorService
    {
        IEnumerable<string> Validate(VmSetting setting);
    }
}
