using Abp.Application.Services.Dto;

namespace LibrarySystem_VA.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

