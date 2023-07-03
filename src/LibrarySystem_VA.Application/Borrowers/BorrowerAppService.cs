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
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LibrarySystem_VA.Borrowers
{
    public class BorrowerAppService : AsyncCrudAppService<Borrower, BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>, IBorrowerAppService
    {
        private readonly IRepository<Borrower, int> _repository;
        private readonly IRepository<Book> _bookRepository;

        public BorrowerAppService(IRepository<Borrower, int> repository, IRepository<Book> bookRepository) : base(repository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public override async Task<BorrowerDto> CreateAsync(CreateBorrowerDto input)
        {
            var borrower = ObjectMapper.Map<Borrower>(input);
            await _repository.InsertAsync(borrower);
            
            var book = await _bookRepository.GetAsync(input.BookId);
            book.IsBorrowed = true;
            await _bookRepository.UpdateAsync(book);

            return base.MapToEntityDto(borrower);
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

        public override async Task<BorrowerDto> UpdateAsync(BorrowerDto input)
        {
            try
            {
                var borrower = await _repository.GetAll().AsNoTracking().Where(x => x.Id == input.Id).FirstOrDefaultAsync();

                if (input.ReturnDate.HasValue)
                {
                    var book = await _bookRepository.GetAsync(input.BookId);
                    book.IsBorrowed = false;
                    await _bookRepository.UpdateAsync(book);
                }

                if (borrower.BookId != input.BookId)
                {
                    var oldBook = await _bookRepository.GetAsync(borrower.BookId.Value);
                    oldBook.IsBorrowed = false;
                    await _bookRepository.UpdateAsync(oldBook);
                                        
                    var newBook = await _bookRepository.GetAsync(input.BookId);
                    newBook.IsBorrowed = true;
                    await _bookRepository.UpdateAsync(newBook);
                }

                borrower = ObjectMapper.Map<Borrower>(input);
                await _repository.UpdateAsync(borrower);               

                return base.MapToEntityDto(borrower);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        protected override Task<Borrower> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }

        public async Task<PagedResultDto<BorrowerDto>> GetAllBorrowerWithStudentAndBook(PagedBorrowerResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Book)
                .Include(x => x.Student)
                .Select(x => ObjectMapper.Map<BorrowerDto>(x))
                .ToListAsync();

            return new PagedResultDto<BorrowerDto>(query.Count(), query);
        }

        public async Task<BorrowerDto> GetBorrowerWithBook(int id)
        {
            var borrower = await _repository.GetAll()
                .Include(x => x.Book)
                .Where(x => x.Id == id)
                .Select(s => ObjectMapper.Map<BorrowerDto>(s))
                .FirstOrDefaultAsync();

            return borrower;
        }    
    }
}
