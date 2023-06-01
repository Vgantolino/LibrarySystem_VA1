using System.ComponentModel.DataAnnotations;

namespace LibrarySystem_VA.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}