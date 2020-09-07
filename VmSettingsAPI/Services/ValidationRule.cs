using System.Collections.Generic;
using VmSettingsAPI.Models;

namespace VmSettingsAPI.Services
{
    public delegate IEnumerable<string> ValidationRule(VmSetting setting);
}