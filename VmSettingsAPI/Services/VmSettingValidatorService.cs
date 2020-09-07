using System.Collections.Generic;
using VmSettingsAPI.Models;

namespace VmSettingsAPI.Services
{
    public class VmSettingValidatorService : IVmSettingValidatorService
    {
        private const int MaxLength = 32;
        private const int MinLength = 3;
        private readonly IEnumerable<ValidationRule> _validationRules;

        public VmSettingValidatorService()
        {
            _validationRules = new List<ValidationRule>
            {
                ValidateVmName,
                ValidateDisplay
            };
        }

        public IEnumerable<string> Validate(VmSetting setting)
        {
            var errors = new List<string>();

            foreach (var rule in _validationRules) errors.AddRange(rule(setting));

            return errors;
        }

        private static IEnumerable<string> ValidateVmName(VmSetting setting)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(setting.VmName)) errors.Add($"{nameof(setting.VmName)} cannot be blank");

            if (setting.VmName.Length > MaxLength) errors.Add($"{nameof(setting.VmName)} length must be less than {MaxLength}");

            if (setting.VmName.Length < MinLength) errors.Add($"{nameof(setting.VmName)} length must be greater than {MinLength}");

            return errors;
        }

        private static IEnumerable<string> ValidateDisplay(VmSetting setting)
        {
            var errors = new List<string>();

            if (setting.Display == null) errors.Add($"{nameof(VmSetting.Display)} cannot be null");

            return errors;
        }
    }
}
