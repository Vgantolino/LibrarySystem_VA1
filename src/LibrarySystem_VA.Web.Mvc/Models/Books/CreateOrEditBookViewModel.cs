using LibrarySystem_VA.BookCategories.Dto;
using LibrarySystem_VA.Entities;
using System.Collections.Generic;

namespace LibrarySystem_VA.Web.Models.Books
{
    public class CreateOrEditBookViewModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookPublisher { get; set; }
        public string BookAuthor { get; set; }
        public string IsBorrowed { get; set; }
        public int BookCategoryId { get; set; }
        public List<BookCategoryDto> BookCategoryList { get; set; }
    }
}
