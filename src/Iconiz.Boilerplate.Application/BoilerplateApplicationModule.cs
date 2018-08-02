using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Iconiz.Boilerplate.Authorization;

namespace Iconiz.Boilerplate
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(BoilerplateCoreModule)
        )]
    public class BoilerplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerplateApplicationModule).GetAssembly());
        }
    }
}