using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Iconiz.Boilerplate
{
    [DependsOn(typeof(BoilerplateXamarinSharedModule))]
    public class BoilerplateXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerplateXamarinAndroidModule).GetAssembly());
        }
    }
}