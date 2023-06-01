using System.Threading.Tasks;
using Abp.Application.Services;
using LibrarySystem_VA.Authorization.Accounts.Dto;

namespace LibrarySystem_VA.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
