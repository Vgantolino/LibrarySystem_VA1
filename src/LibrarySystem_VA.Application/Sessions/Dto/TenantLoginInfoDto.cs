using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystem_VA.MultiTenancy;

namespace LibrarySystem_VA.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
