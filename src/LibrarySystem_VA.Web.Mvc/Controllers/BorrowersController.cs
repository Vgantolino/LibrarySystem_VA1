using Abp.Application.Services.Dto;
using LibrarySystem_VA.Books;
using LibrarySystem_VA.Books.Dto;
using LibrarySystem_VA.Borrowers;
using LibrarySystem_VA.Borrowers.Dto;
using LibrarySystem_VA.Controllers;
using LibrarySystem_VA.Students;
using LibrarySystem_VA.Students.Dto;
using LibrarySystem_VA.Web.Models.Borrowers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Web.Controllers
{
    public class BorrowersController : LibrarySystem_VAControllerBase
    {
        private IBorrowerAppService _borrowerAppService;
        private IBookAppService _bookAppService;
        private IStudentAppService _studentAppService;

        public BorrowersController(IBorrowerAppService borrowerAppService, IBookAppService bookAppService, IStudentAppService studentAppService)
        {
            _borrowerAppService = borrowerAppService;
            _bookAppService = bookAppService;
            _studentAppService = studentAppService;
        }

        public async Task<IActionResult> Index()
        {
            var borrower = await _borrowerAppService.GetAllBorrowerWithStudentAndBook(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BorrowerListViewModel()
            {
                Borrowers = borrower.Items.ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int id)
        {
            var model = new CreateOrEditBorrowerViewModel();
            var book = await _bookAppService.GetAllAsync(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });
            var student = await _studentAppService.GetAllAsync(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });

            if (id != 0)
            {
                var borrower = await _borrowerAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditBorrowerViewModel()
                {
                    Id = id,
                    BorrowDate = borrower.BorrowDate,
                    ExpectedReturnDate = borrower.ExpectedReturnDate,
                    ReturnDate = borrower.ReturnDate,
                    BookId = borrower.BookId,
                    StudentId = borrower.StudentId
                };

                model.BookList = book.Items.ToList();
            }
            else
            {
                model.BookList = book.Items.Where(x => x.IsBorrowed == false).ToList();                
            }

            model.StudentList = student.Items.ToList();
            return View(model);
        }

    }
}
