using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.BookCategories.Dto
{
    [AutoMapFrom(typeof(BookCategory))]
    [AutoMapTo(typeof(BookCategory))]

    public class BookCategoryDto : EntityDto<int>
    {
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
