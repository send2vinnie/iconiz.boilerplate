using System.Threading.Tasks;
using Iconiz.Boilerplate.Sessions.Dto;

namespace Iconiz.Boilerplate.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
