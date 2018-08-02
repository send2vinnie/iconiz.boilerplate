using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Iconiz.Boilerplate
{
    public class BoilerplateClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerplateClientModule).GetAssembly());
        }
    }
}
