using Abp.Application.Services.Dto;
using LibrarySystem_VA.Authors;
using LibrarySystem_VA.Authors.Dto;
using LibrarySystem_VA.BookCategories;
using LibrarySystem_VA.BookCategories.Dto;
using LibrarySystem_VA.Books;
using LibrarySystem_VA.Books.Dto;
using LibrarySystem_VA.Controllers;
using LibrarySystem_VA.Entities;
using LibrarySystem_VA.EntityFrameworkCore;
using LibrarySystem_VA.Web.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Web.Controllers
{
    public class BooksController : LibrarySystem_VAControllerBase
    {

        private readonly IBookAppService _bookAppService;
        private readonly IBookCategoryAppService _bookCategoryAppService;
        private readonly IAuthorAppService _authorAppService;

        public BooksController(IBookAppService bookAppService, IBookCategoryAppService bookCategoryAppService, IAuthorAppService authorAppService)
        {
            _bookCategoryAppService = bookCategoryAppService;
            _bookAppService = bookAppService;
        }

        public async Task<IActionResult> Index(string searchBooks)
        {
            var books = await _bookAppService.GetAllBooksWithBookCategory(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BookListViewModel();

            if (!string.IsNullOrEmpty(searchBooks))
            {
                model = new BookListViewModel()
                {
                    Books = books.Items.Where(b => b.BookTitle.Contains(searchBooks) ||
                                                   b.BookPublisher.Contains(searchBooks) ||
                                                   b.BookCategory.Name.Contains(searchBooks)).ToList()
                };

            }
            else
            {
                model = new BookListViewModel()
                {
                    Books = books.Items.ToList()                    
                };
            }           
          
            return View(model);
        }       
        
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            var model = new CreateOrEditBookViewModel();
            var bookCategory = await _bookCategoryAppService.GetAllAsync(new PagedBookCategoryResultRequestDto { MaxResultCount = int.MaxValue });
            var bookAuthor = await _authorAppService.GetAllAsync(new PagedAuthorResultRequestDto { MaxResultCount = int.MaxValue });

            if (id != 0)
            {
                var books = await _bookAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditBookViewModel()
                {
                    Id = id,
                    BookTitle = books.BookTitle,
                    BookPublisher = books.BookPublisher,
                    BookCategoryId = books.BookCategoryId,
                    AuthorId = books.AuthorId
                };
            }

            model.BookCategoryList = bookCategory.Items.ToList();
            model.AuthorList = bookAuthor.Items.ToList();
            return View(model);
        }
        
    }
}
