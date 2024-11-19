using booklibrarys.DTOs.AuthorDtos;
using booklibrarys.DTOs.BookDtos;
using booklibrarys.Models;
using Microsoft.EntityFrameworkCore;

namespace booklibrarys.Repo.AuthorRepos
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context; 
        public AuthorRepo(AppDbContext context)
        { 
            _context= context;
        }
        public void AddAuthorBook(AuthorBookDto authorBookDto)
        {
            var authorbook = new Author
            {
                AuthorName = authorBookDto.AuthorName,
                AuthorEmail = authorBookDto.AuthorEmail,
                PhoneNumber = authorBookDto.PhoneNumber,
                Books=authorBookDto.BookDto.Select(x=>new Book
                {
                    Title = x.Title,
                    PublishedYear= x.PublishedYear,
                }).ToList(),
            };
            _context.Authors.Add(authorbook);
            _context.SaveChanges();
        }

        public void AddAuthorOnly(AuthorDto authorDto)
        {
            var author = new Author
            {
                AuthorName=authorDto.AuthorName,
                AuthorEmail=authorDto.AuthorEmail,
                PhoneNumber=authorDto.PhoneNumber,
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthorBook(int id)
        {
            var author = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorId == id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public List<AuthorBookDto>GetAll()
        {
            var AllAuthors = _context.Authors.Include(x => x.Books).Select(x => new AuthorBookDto
            {
                AuthorName=x.AuthorName,
                AuthorEmail=x.AuthorEmail,
                PhoneNumber=x.PhoneNumber,
                BookDto = x.Books.Select(x=>new BookDto
                {
                    Title=x.Title,
                    PublishedYear=x.PublishedYear,

                }).ToList(),
            }).ToList();
            return AllAuthors;
        }

        public AuthorBookDto GetById(int id)
        {
            var author = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorId == id);
            return new AuthorBookDto
            {
                AuthorName = author.AuthorName,
                AuthorEmail = author.AuthorEmail,
                PhoneNumber = author.PhoneNumber,
                BookDto=author.Books.Select(x=>new BookDto
                { 
                    Title = x.Title,
                PublishedYear= x.PublishedYear,
                }).ToList(),
            };
            
        }

        public void UpdateAuthorBook(AuthorBookDto authorBookDto, int id)
        {
            var author = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorId == id);
            author.AuthorName = authorBookDto.AuthorName;
            author.AuthorEmail=authorBookDto.AuthorEmail;
            author.PhoneNumber=authorBookDto.PhoneNumber;
           author.Books = authorBookDto.BookDto.Select(x=>new Book
           {
               Title = x.Title,
               PublishedYear= x.PublishedYear,
           }).ToList();
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}
