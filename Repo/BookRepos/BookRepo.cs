using booklibrarys.DTOs.AuthorDtos;
using booklibrarys.DTOs.BookDtos;
using booklibrarys.DTOs.GenreDtos;
using booklibrarys.Models;
using Microsoft.EntityFrameworkCore;

namespace booklibrarys.Repo.BookRepos
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context) 
        { 
            _context= context;

        }
        public void AddBookAuthor(BookAuthorDto bookAuthorDto)
        {
            var book = new Book()
            {
                Title = bookAuthorDto.Title,
                PublishedYear = bookAuthorDto.PublishedYear,
                Genres = bookAuthorDto.GenreDtos.Select(x => new Genre
                {
                  Name = x.Name,
                }).ToList(),
                Authors=bookAuthorDto.AuthorDtos.Select(x => new Author
                {
                    AuthorName=x.AuthorName,
                    AuthorEmail=x.AuthorEmail,
                    PhoneNumber=x.PhoneNumber,

                }).ToList(),
            };
            _context.Books.Add(book);
            _context.SaveChanges();

           
        }

        public void DeleteBookAuthor(int id)
        {
            var book= _context.Books.Include(x=>x.Authors).Include(x=>x.Genres).FirstOrDefault(x=>x.BookId==id);   
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public BookAuthorDto GetBookAuthor(int id)
        {
            var book = _context.Books.Include(x => x.Authors).Include(x => x.Genres).FirstOrDefault(x => x.BookId == id);
            return new BookAuthorDto
            {
                Title = book.Title,
                PublishedYear = book.PublishedYear,
                AuthorDtos = book.Authors.Select(x => new AuthorDto
                {
                    AuthorName=x.AuthorName,
                    AuthorEmail=x.AuthorEmail,
                    PhoneNumber=x.PhoneNumber,
                }).ToList(),
                GenreDtos=book.Genres.Select(x => new GenreDto { 
                    Name=x.Name,
                }).ToList(),
            };
        }

        public List<BookAuthorDto> GetBookAuthorAll()
        {
            var book = _context.Books.Include(x => x.Authors).Include(x => x.Genres).Select(x => new BookAuthorDto
            {
                Title=x.Title,
                PublishedYear=x.PublishedYear,
                AuthorDtos=x.Authors.Select(x => new AuthorDto
                {
                    AuthorName=x.AuthorName,
                    AuthorEmail=x.AuthorEmail,
                    PhoneNumber=x.PhoneNumber,
                }).ToList(),
                GenreDtos=x.Genres.Select(x=> new GenreDto
                {
                    Name=x.Name,
                }).ToList(),
            }).ToList();
            return book;
        }

        public void UpdateBookAuthor(BookAuthorDto bookAuthorDto, int id)
        {
            var book = _context.Books.Include(x => x.Authors).Include(x => x.Genres).FirstOrDefault(x => x.BookId == id);
            book.Title=bookAuthorDto.Title;
            book.PublishedYear=bookAuthorDto.PublishedYear;
            book.Authors = bookAuthorDto.AuthorDtos.Select(x=>new Author
            {
                AuthorName=x.AuthorName,
                AuthorEmail=x.AuthorEmail,
                PhoneNumber=x.PhoneNumber,

            }).ToList();
            book.Genres = bookAuthorDto.GenreDtos.Select(x => new Genre
            {
                Name= x.Name,

            }).ToList();
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
