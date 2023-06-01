using Abp.Application.Services.Dto;
using LibrarySystem_VA.Controllers;
using LibrarySystem_VA.Departments;
using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Web.Models.Departments;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Web.Controllers
{
    public class DepartmentsController : LibrarySystem_VAControllerBase
    {

        private IDepartmentAppService _departmentAppService;

        public DepartmentsController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        public async Task<IActionResult> Index()
        {

            var departments = await _departmentAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new DepartmentListViewModel()
            {
                Departments = departments.Items.ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            var model = new CreateOrEditDepartmentViewModel();

            if (id.HasValue)
            {
                var department = await _departmentAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditDepartmentViewModel()
                {
                    Id = department.Id,
                    Name = department.Name
                };
            }

            return View(model);
        }

    }
}
