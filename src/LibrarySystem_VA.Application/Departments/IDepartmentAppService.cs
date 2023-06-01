using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystem_VA.BookCategories.Dto;
using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Entities;
using LibrarySystem_VA.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Departments
{
    public interface IDepartmentAppService : IAsyncCrudAppService<DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>
    { 
    }
}
