using System.Threading.Tasks;

namespace Iconiz.Boilerplate.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}