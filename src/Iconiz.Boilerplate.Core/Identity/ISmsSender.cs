using System.Threading.Tasks;

namespace Iconiz.Boilerplate.Identity
{
    public interface ISmsSender
    {
        void Send(string to, string templateCode, string templateParams);
        Task SendAsync(string to, string templateCode, string templateParams);
    }
}