using VmSettingsAPI.Models;

namespace VmSettingsAPI.Services
{
    public interface IVmSettingService
    {
        VmSetting Load();
        bool Write(VmSetting vmSetting);
    }
}
