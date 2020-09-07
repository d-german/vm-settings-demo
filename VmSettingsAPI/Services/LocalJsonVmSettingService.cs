using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using VmSettingsAPI.Models;

namespace VmSettingsAPI.Services
{
    public class LocalJsonVmSettingService : IVmSettingService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public LocalJsonVmSettingService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public VmSetting Load()
        {
            using (var file = new FileStream(GetPathToSetting(), FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var jsonReader = new StreamReader(file))
            {
                var json = jsonReader.ReadToEnd();

                return JsonConvert.DeserializeObject<VmSetting>(json);
            }
        }

        public bool Write(VmSetting vmSetting)
        {
            var content = JsonConvert.SerializeObject(vmSetting, Formatting.Indented);

            try
            {
                using (var file = new FileStream(GetPathToSetting(), FileMode.Truncate, FileAccess.Write, FileShare.None))
                using (var jsonWriter = new StreamWriter(file))
                {
                    jsonWriter.Write(content);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetPathToSetting()
        {
            var slash = Path.DirectorySeparatorChar;
            return $"{_hostingEnvironment.ContentRootPath}{slash}vmSetting.json";
        }
    }
}
