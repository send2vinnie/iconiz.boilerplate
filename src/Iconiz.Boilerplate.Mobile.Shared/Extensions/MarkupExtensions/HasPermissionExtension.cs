using System;
using Iconiz.Boilerplate.Core;
using Iconiz.Boilerplate.Core.Dependency;
using Iconiz.Boilerplate.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Iconiz.Boilerplate.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}