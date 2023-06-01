using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystem_VA.Authorization.Users;
using LibrarySystem_VA.BookCategories.Dto;
using LibrarySystem_VA.Books.Dto;
using LibrarySystem_VA.Entities;
using LibrarySystem_VA.Students.Dto;
using LibrarySystem_VA.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.BookCategories
{
    public class BookCategoryAppService : AsyncCrudAppService<BookCategory, BookCategoryDto, int, PagedBookCategoryResultRequestDto, CreateBookCategoryDto, BookCategoryDto>, IBookCategoryAppService
    {

        private readonly IRepository<BookCategory, int> _repository;        
        private readonly IRepository<Department> _departmentRepository;

        public BookCategoryAppService(
            IRepository<BookCategory, int> repository,
            IRepository<Department> departmentRepository) : base(repository)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
        }

        public override Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BookCategoryDto>> GetAllAsync(PagedBookCategoryResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BookCategoryDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookCategoryDto> UpdateAsync(BookCategoryDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<BookCategory> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }

        public async Task<PagedResultDto<BookCategoryDto>> GetAllBookCategoriesWithDepartment(PagedBookCategoryResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Department)
                .Select(x => ObjectMapper.Map<BookCategoryDto>(x))
                .ToListAsync();

            return new PagedResultDto<BookCategoryDto>(query.Count(), query);
        }

    }
}
