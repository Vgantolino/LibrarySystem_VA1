using Abp.Application.Services;
using LibrarySystem_VA.MultiTenancy.Dto;

namespace LibrarySystem_VA.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

