using Xamarin.Forms.Internals;

namespace Iconiz.Boilerplate.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}