using Abp.Application.Services.Dto;
using LibrarySystem_VA.Books;
using LibrarySystem_VA.Books.Dto;
using LibrarySystem_VA.Borrowers;
using LibrarySystem_VA.Borrowers.Dto;
using LibrarySystem_VA.Controllers;
using LibrarySystem_VA.Entities;
using LibrarySystem_VA.Students;
using LibrarySystem_VA.Students.Dto;
using LibrarySystem_VA.Web.Models.Borrowers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<IActionResult> Index(string searchBorrower)
        {
            var borrower = await _borrowerAppService.GetAllBorrowerWithStudentAndBook(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BorrowerListViewModel();

            if (!string.IsNullOrEmpty(searchBorrower))
            {
                model = new BorrowerListViewModel()
                {
                    Borrowers = borrower.Items.Where(o => o.Book.BookTitle.Contains(searchBorrower) ||
                                                          o.Student.StudentName.Contains(searchBorrower)).ToList()
                };
            }
            else
            {
                model = new BorrowerListViewModel()
                {
                    Borrowers = borrower.Items.ToList()
                };
            }

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int id)
        {
            var model = new CreateOrEditBorrowerViewModel();
            var books = await _bookAppService.GetAllAuthorsUnderBooks();
            var student = await _studentAppService.GetAllStudents();

            if (id != 0)
            {
                var borrower = await _borrowerAppService.GetBorrowerWithBook(id);
                model = new CreateOrEditBorrowerViewModel()
                {
                    Id = id,
                    BorrowDate = borrower.BorrowDate,
                    ExpectedReturnDate = borrower.ExpectedReturnDate,
                    ReturnDate = borrower.ReturnDate,
                    BookId = borrower.BookId,
                    IsBorrowed = borrower.Book.IsBorrowed,
                    StudentId = borrower.StudentId
                };
                var book = await _bookAppService.GetAsync(new EntityDto<int>(borrower.BookId));
                books.Add(book);
            }

            model.BookList = books;
            model.StudentList = student;
            return View(model);
        }

    }
}
