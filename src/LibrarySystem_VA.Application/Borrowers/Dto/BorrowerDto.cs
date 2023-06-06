using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystem_VA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Borrowers.Dto
{
    [AutoMapFrom(typeof(Borrower))]
    [AutoMapTo(typeof(Borrower))]

    public class BorrowerDto : EntityDto<int>
    {
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
