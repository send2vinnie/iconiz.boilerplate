using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using Iconiz.Boilerplate.Configuration;

namespace Iconiz.Boilerplate.Tests.Configuration
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(BoilerplateTestModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
