using booklibrarys.DTOs.BookDtos;
using System.ComponentModel.DataAnnotations;

namespace booklibrarys.DTOs.AuthorDtos
{
    public class AuthorBookDto
    {
        [Required]
        public string AuthorName { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string AuthorEmail { get; set; }
        public List<BookDto> BookDto { get; set; }
    }
}
