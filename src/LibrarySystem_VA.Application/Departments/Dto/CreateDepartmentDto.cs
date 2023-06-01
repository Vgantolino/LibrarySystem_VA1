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
    [AutoMapTo(typeof(Department))]

    public class CreateDepartmentDto : EntityDto<int>
    {
        public string Name { get; set; }

    }   

}
