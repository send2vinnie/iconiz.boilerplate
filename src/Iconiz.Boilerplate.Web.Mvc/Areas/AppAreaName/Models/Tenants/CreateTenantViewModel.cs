using System.Collections.Generic;
using Iconiz.Boilerplate.Editions.Dto;
using Iconiz.Boilerplate.Security;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Tenants
{
    public class CreateTenantViewModel
    {
        public IReadOnlyList<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public CreateTenantViewModel(IReadOnlyList<SubscribableEditionComboboxItemDto> editionItems)
        {
            EditionItems = editionItems;
        }
    }
}