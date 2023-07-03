using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystem_VA.Borrowers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Borrowers
{
    public interface IBorrowerAppService : IAsyncCrudAppService<BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>
    {
        Task<PagedResultDto<BorrowerDto>> GetAllBorrowerWithStudentAndBook(PagedBorrowerResultRequestDto input);
        Task<BorrowerDto> GetBorrowerWithBook(int id);
        //Task UpdateIsBorrowedIfDeletedInBorrowers(BorrowerDto input);
    }
}
