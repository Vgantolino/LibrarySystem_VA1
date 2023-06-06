using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem_VA.Entities;
using LibrarySystem_VA.Borrowers.Dto;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;

namespace LibrarySystem_VA.Borrowers
{
    public class BorrowerAppService : AsyncCrudAppService<Borrower, BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>, IBorrowerAppService
    {
        public BorrowerAppService(IRepository<Borrower, int> repository) : base(repository)
        {
        }

        public override Task<BorrowerDto> CreateAsync(CreateBorrowerDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BorrowerDto>> GetAllAsync(PagedBorrowerResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BorrowerDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BorrowerDto> UpdateAsync(BorrowerDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Borrower> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
    }
}
