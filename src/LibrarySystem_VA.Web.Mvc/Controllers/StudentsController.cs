using Abp.Application.Services.Dto;
using LibrarySystem_VA.Controllers;
using LibrarySystem_VA.Departments;
using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Entities;
using LibrarySystem_VA.Students;
using LibrarySystem_VA.Students.Dto;
using LibrarySystem_VA.Web.Models.Students;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Web.Controllers
{
    public class StudentsController : LibrarySystem_VAControllerBase
    {

        private IStudentAppService _studentAppService;
        private IDepartmentAppService _departmentAppService;

        public StudentsController(IStudentAppService studentAppService, IDepartmentAppService departmentAppService)
        {
            _studentAppService = studentAppService;
            _departmentAppService = departmentAppService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentAppService.GetAllDepartment(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue }); //get all the students in DB from appservice

            //ipapasa sa index (controller > html) model >> controller
            var model = new StudentListViewModel()
            {
                Students = students.Items.ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            var model = new CreateOrEditStudentViewModel();
            var department = await _departmentAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue});

            if (id.HasValue)
            {
                var student = await _studentAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditStudentViewModel()
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    StudentContactNumber = student.StudentContactNumber,
                    StudentEmail = student.StudentEmail,
                    DepartmentId = student.DepartmentId
                };
            }

            model.DepartmentList = department.Items.ToList();
            return View(model);
        }
    }
}
