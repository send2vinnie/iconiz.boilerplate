using System.Collections.Generic;
using MvvmHelpers;
using Iconiz.Boilerplate.Models.NavigationMenu;

namespace Iconiz.Boilerplate.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}