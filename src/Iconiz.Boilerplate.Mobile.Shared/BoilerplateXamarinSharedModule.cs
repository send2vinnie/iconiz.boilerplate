using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Iconiz.Boilerplate
{
    [DependsOn(typeof(BoilerplateClientModule), typeof(AbpAutoMapperModule))]
    public class BoilerplateXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerplateXamarinSharedModule).GetAssembly());
        }
    }
}