using booklibrarys.DTOs.AuthorDtos;
using booklibrarys.DTOs.GenreDtos;
using System.ComponentModel.DataAnnotations;

namespace booklibrarys.DTOs.BookDtos
{
    public class BookAuthorDto
    {
        [Required]
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }

        public List<AuthorDto> AuthorDtos { get; set; }
        public List<GenreDto> GenreDtos { get; set; }
    }
}
