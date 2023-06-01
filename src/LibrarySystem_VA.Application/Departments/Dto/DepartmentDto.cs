using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystem_VA.Authorization.Users;
using LibrarySystem_VA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Departments.Dto
{
    [AutoMapFrom(typeof(Department))]
    [AutoMapTo(typeof(Department))]

    public class DepartmentDto : EntityDto<int>
    {
        public string Name { get; set; }
    }

}
