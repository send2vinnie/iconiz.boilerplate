using System.Threading.Tasks;

namespace Iconiz.Boilerplate.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
