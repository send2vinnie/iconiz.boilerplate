using Microsoft.Extensions.Configuration;

namespace Iconiz.Boilerplate.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
