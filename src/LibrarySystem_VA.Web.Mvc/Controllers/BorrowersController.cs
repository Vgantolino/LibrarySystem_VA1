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
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Web.Controllers
{
    public class BorrowersController : LibrarySystem_VAControllerBase
    {
        private readonly IBorrowerAppService _borrowerAppService;
        private readonly IBookAppService _bookAppService;
        private readonly IStudentAppService _studentAppService;

        public BorrowersController(IBorrowerAppService borrowerAppService, IBookAppService bookAppService, IStudentAppService studentAppService)
        {
            _borrowerAppService = borrowerAppService;
            _bookAppService = bookAppService;
            _studentAppService = studentAppService;
        }

        public async Task<IActionResult> Index()
        {
            var borrowers = await _borrowerAppService.GetAllBorrowersWithBookAndStudent(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BorrowerListViewModel()
            {
                Borrowers = borrowers.Items.ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Create(int id)
        {
            var model = new CreateOrEditBorrowerViewModel();
            var book = await _bookAppService.GetAllAsync(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });
            var student = await _studentAppService.GetAllAsync(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });

            model = new CreateOrEditBorrowerViewModel()
            {
                //        Id = id,
                //        BorrowDate = borrowers.BorrowDate,
                //        ExpectedReturnDate = borrowers.ExpectedReturnDate,
                //        ReturnDate = borrowers.ReturnDate,
                //        BookId = borrowers.BookId,
                //        StudentId = borrowers.StudentId
            };


            //if (id != 0)
            //{
            //    var borrowers = await _borrowerAppService.GetAsync(new EntityDto<int>(id));
            //    model = new CreateOrEditBorrowerViewModel()
            //    {
            //        Id = id,
            //        BorrowDate = borrowers.BorrowDate,
            //        ExpectedReturnDate = borrowers.ExpectedReturnDate,
            //        ReturnDate = borrowers.ReturnDate,
            //        BookId = borrowers.BookId,
            //        StudentId = borrowers.StudentId
            //    };
            //}

            model.BookList = book.Items.ToList();
            model.StudentList = student.Items.ToList();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = new CreateOrEditBorrowerViewModel();
            var book = await _bookAppService.GetAllAsync(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });
            var student = await _studentAppService.GetAllAsync(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });

            if (id != 0)
            {
                var borrowers = await _borrowerAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditBorrowerViewModel()
                {
                    Id = id,
                    BorrowDate = borrowers.BorrowDate,
                    ExpectedReturnDate = borrowers.ExpectedReturnDate,
                    ReturnDate = borrowers.ReturnDate,
                    BookId = borrowers.BookId,
                    StudentId = borrowers.StudentId
                };
            }

            model.BookList = book.Items.ToList();
            model.StudentList = student.Items.ToList();
            return View(model);
        }
    }
}
