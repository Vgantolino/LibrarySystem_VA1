using Abp.AutoMapper;
using LibrarySystem_VA.Sessions.Dto;

namespace LibrarySystem_VA.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
