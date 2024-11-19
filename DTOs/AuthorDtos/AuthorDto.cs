using System.ComponentModel.DataAnnotations;

namespace booklibrarys.DTOs.AuthorDtos
{
    public class AuthorDto
    {
        [Required]
        public string AuthorName { get; set; }
        [Phone(ErrorMessage ="Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string AuthorEmail { get; set; }
    }
}
