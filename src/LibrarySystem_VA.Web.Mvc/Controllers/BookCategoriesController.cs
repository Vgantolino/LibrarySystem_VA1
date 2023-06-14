using Abp.Application.Services.Dto;
using LibrarySystem_VA.BookCategories;
using LibrarySystem_VA.BookCategories.Dto;
using LibrarySystem_VA.Controllers;
using LibrarySystem_VA.Departments;
using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Web.Models.BookCategories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Web.Controllers
{
    public class BookCategoriesController : LibrarySystem_VAControllerBase
    {
        private IBookCategoryAppService _BookCategoryAppService;
        private IDepartmentAppService _departmentAppService;

        public BookCategoriesController(IBookCategoryAppService bookCategoryAppService, IDepartmentAppService departmentAppService)
        {
            _BookCategoryAppService = bookCategoryAppService;
            _departmentAppService = departmentAppService;
        }

        public async Task<IActionResult> Index(string searchBookCategory)
        {
            var bookCategories = await _BookCategoryAppService.GetAllBookCategoriesWithDepartment(new PagedBookCategoryResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BookCategoryListViewModel();

            if (!string.IsNullOrEmpty(searchBookCategory))
            {
                model = new BookCategoryListViewModel()
                {
                    BookCategories = bookCategories.Items.Where(b => b.Name.Contains(searchBookCategory) ||
                                                                     b.Department.Name.Contains(searchBookCategory)).ToList()
                };
            }
            else
            {
                model = new BookCategoryListViewModel()
                {
                    BookCategories = bookCategories.Items.ToList()
                };
            }

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int id)
        {

            var model = new CreateOrEditBookCategoryViewModel();
            var department = await _departmentAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue });

            if (id != 0)
            {
                var bookCategory = await _BookCategoryAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditBookCategoryViewModel()
                {
                    Id = id,
                    Name = bookCategory.Name,
                    DepartmentId = bookCategory.DepartmentId
                };
            }

            model.DepartmentList = department.Items.ToList();
            return View(model);
        }

    }
}
