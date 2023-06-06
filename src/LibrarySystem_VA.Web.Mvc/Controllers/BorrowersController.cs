using LibrarySystem_VA.Borrowers;
using LibrarySystem_VA.Borrowers.Dto;
using LibrarySystem_VA.Controllers;
using LibrarySystem_VA.Web.Models.Borrowers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Web.Controllers
{
    public class BorrowersController : LibrarySystem_VAControllerBase
    {
        private readonly IBorrowerAppService _borrowerAppService;

        public BorrowersController(IBorrowerAppService borrowerAppService)
        {
            _borrowerAppService = borrowerAppService;
        }

        public async Task<IActionResult> Index()
        {
            var borrowers = await _borrowerAppService.GetAllAsync(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BorrowerListViewModel()
            {
                Borrowers = borrowers.Items.ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit()
        {
            return View();
        }
    }
}
