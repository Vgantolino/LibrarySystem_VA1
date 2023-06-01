using Abp.Application.Services.Dto;
using LibrarySystem_VA.Authors;
using LibrarySystem_VA.Authors.Dto;
using LibrarySystem_VA.Controllers;
using LibrarySystem_VA.Web.Models.Authors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Web.Controllers
{
    public class AuthorsController : LibrarySystem_VAControllerBase
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorsController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public async Task<IActionResult> Index(string searchAuthors)
        {
            var authors = await _authorAppService.GetAllAsync(new PagedAuthorResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new AuthorListViewModel();

            if (!string.IsNullOrEmpty(searchAuthors))
            {
                model = new AuthorListViewModel()
                {
                    Authors = authors.Items.Where(a => a.Name.Contains(searchAuthors)).ToList()
                };
            }
            else
            {
                model = new AuthorListViewModel()
                {
                    Authors = authors.Items.ToList()
                };
            }

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int id)
        {
            var model = new CreateOrEditAuthorViewModel();

            if (id != 0)
            {
                var author = await _authorAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditAuthorViewModel()
                {
                    Id = id,
                    Name = author.Name
                };
            }

            return View(model);
        }

    }
}
