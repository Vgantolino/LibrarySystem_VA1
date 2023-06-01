using Abp.Application.Services.Dto;
using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem_VA.Web.Models.Students
{
    public class CreateOrEditStudentViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentContactNumber { get; set; }
        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public Department DepartmentFK { get; set; }

        public List<DepartmentDto> DepartmentList { get; set; }

    }
}
