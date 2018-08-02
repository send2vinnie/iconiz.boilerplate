using Iconiz.Boilerplate.Models.Tenants;
using Iconiz.Boilerplate.ViewModels;
using Xamarin.Forms;

namespace Iconiz.Boilerplate.Views
{
    public partial class TenantsView : ContentPage, IXamarinView
    {
        public TenantsView()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((TenantsViewModel)BindingContext).LoadMoreTenantsIfNeedsAsync(e.Item as TenantListModel);
        }
    }
}