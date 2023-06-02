using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystem_VA.Authors.Dto;
using LibrarySystem_VA.Books.Dto;
using LibrarySystem_VA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Books
{
    public interface IBookAppService : IAsyncCrudAppService<BookDto,int,PagedBookResultRequestDto,CreateBookDto,BookDto>
    {
       Task<PagedResultDto<BookDto>> GetAllBooksWithBookCategory(PagedBookResultRequestDto input);
        //Task<PagedResultDto<AuthorDto>> GetAllBooksWithBookAuthor(PagedAuthorResultRequestDto input);
    }
}
