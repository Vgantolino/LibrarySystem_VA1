using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Entities;
using System.Collections.Generic;

namespace LibrarySystem_VA.Web.Models.BookCategories
{
    public class CreateOrEditBookCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public List<DepartmentDto> DepartmentList { get; set; }
    }
}
