using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using LibrarySystem_VA.Books.Dto;
using LibrarySystem_VA.Students.Dto;

namespace LibrarySystem_VA.Web.Models.Borrowers
{
    public class CreateOrEditBorrowerViewModel
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? BookId { get; set; }
        public bool IsBorrowed { get; set; }
        public List<BookDto> BookList { get; set; }
        public int? StudentId { get; set; }
        public List<StudentDto> StudentList { get; set; }
    }
}
