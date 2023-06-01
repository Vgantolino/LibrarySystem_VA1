using System.Threading.Tasks;
using Abp.Application.Services;
using LibrarySystem_VA.Sessions.Dto;

namespace LibrarySystem_VA.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
