using booklibrarys.DTOs.BookDtos;

namespace booklibrarys.Repo.BookRepos
{
    public interface IBookRepo
    {
        public List<BookAuthorDto> GetBookAuthorAll();
        public BookAuthorDto GetBookAuthor (int id);
        public void AddBookAuthor(BookAuthorDto bookAuthorDto);
        public void UpdateBookAuthor(BookAuthorDto bookAuthorDto,int id);
        public void DeleteBookAuthor(int id);

    }
}
