using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystem_VA.BookCategories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.BookCategories
{
    public interface IBookCategoryAppService : IAsyncCrudAppService<BookCategoryDto, int, PagedBookCategoryResultRequestDto, CreateBookCategoryDto, BookCategoryDto>
    {
        Task<PagedResultDto<BookCategoryDto>> GetAllBookCategoriesWithDepartment(PagedBookCategoryResultRequestDto input);
    }
}
