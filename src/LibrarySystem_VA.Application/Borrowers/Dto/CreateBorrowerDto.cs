using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystem_VA.Authors.Dto;
using LibrarySystem_VA.BookCategories.Dto;
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

    public class CreateBorrowerDto : EntityDto<int>
    {
        public string BookTitle { get; set; }
        public string BookPublisher { get; set; }
        public bool? IsBorrowed { get; set; }
        public int? BookCategoryId { get; set; }
        public BookCategoryDto BookCategory { get; set; }
        public int? AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}
