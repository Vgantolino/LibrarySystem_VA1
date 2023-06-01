using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>
    {
        Task<PagedResultDto<StudentDto>> GetAllDepartment(PagedStudentResultRequestDto input);

    }
}
