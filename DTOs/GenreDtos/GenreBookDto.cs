using booklibrarys.DTOs.BookDtos;

namespace booklibrarys.DTOs.GenreDtos
{
    public class GenreBookDto
    {
        public string Name { get; set; }
        public List<BookDto> BookDtos { get; set; }
    }
}
