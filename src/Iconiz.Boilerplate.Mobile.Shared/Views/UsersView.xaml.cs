using Iconiz.Boilerplate.Models.Users;
using Iconiz.Boilerplate.ViewModels;
using Xamarin.Forms;

namespace Iconiz.Boilerplate.Views
{
    public partial class UsersView : ContentPage, IXamarinView
    {
        public UsersView()
        {
            InitializeComponent();
        }

        public async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((UsersViewModel) BindingContext).LoadMoreUserIfNeedsAsync(e.Item as UserListModel);
        }
    }
}