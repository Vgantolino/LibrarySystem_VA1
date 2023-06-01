using Abp.Application.Services.Dto;
using System;

namespace LibrarySystem_VA.Departments.Dto
{
    //custom PagedResultRequestDto
    public class PagedDepartmentResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
