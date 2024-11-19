using System.ComponentModel.DataAnnotations;

namespace booklibrarys.DTOs.BookDtos
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }


    }
}
