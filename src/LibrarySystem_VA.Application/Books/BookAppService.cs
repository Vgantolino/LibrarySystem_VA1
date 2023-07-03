using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using LibrarySystem_VA.Authorization.Users;
using LibrarySystem_VA.Authors.Dto;
using LibrarySystem_VA.Books.Dto;
using LibrarySystem_VA.Borrowers.Dto;
using LibrarySystem_VA.Entities;
using LibrarySystem_VA.Roles.Dto;
using LibrarySystem_VA.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Books
{
    public class BookAppService : AsyncCrudAppService<Book, BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>, IBookAppService
    {

        private readonly IRepository<Book, int> _repository;
        private readonly IRepository<BookCategory> _bookCategoryRepository;

        public BookAppService(
            IRepository<Book, int> repository,
            IRepository<BookCategory> bookCategoryRepository) : base(repository)
        {
            _repository = repository;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public override Task<BookDto> CreateAsync(CreateBookDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BookDto>> GetAllAsync(PagedBookResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BookDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookDto> UpdateAsync(BookDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Book> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }

        public async Task<PagedResultDto<BookDto>> GetAllBooksWithBookCategoryAndAuthor(PagedBookResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.BookCategory)
                .Include(x => x.Author)
                .Select(x => ObjectMapper.Map<BookDto>(x))
                .ToListAsync();

            return new PagedResultDto<BookDto>(query.Count(), query);
        }

        public async Task<List<BookDto>> GetAllAuthorsUnderBooks()
        {
            var query = await _repository.GetAll()
                .Include(x => x.BookCategory)
                .Include(x => x.Author)
                .Where(x => !x.IsBorrowed)
                .Select(x => ObjectMapper.Map<BookDto>(x))
                .ToListAsync();

            return query;
        }

        public async Task<BookDto> UpdateIsBorrowedIfDeletedInBorrowers(EntityDto<int> input)
        {
            var book = await GetAsync(input);

            if (book.IsBorrowed == true)
            {
                book.IsBorrowed = false;                
            }

            var updateBook = await UpdateAsync(book);
            return updateBook;
        }
    }
}
