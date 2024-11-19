
using booklibrarys.DTOs.BookDtos;
using booklibrarys.Repo.BookRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace booklibrarys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _repo;
        public BookController(IBookRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("Add Book Author Genre")]
        public IActionResult AddBoookAuthorGenre(BookAuthorDto bookAuthorDto)
        {
            _repo.AddBookAuthor(bookAuthorDto);
            return Created();
        }
        [HttpGet("{id}")]
        public IActionResult GetBookOnly(int id)
        {
            var book = _repo.GetBookAuthor(id);
            return Ok(book);
        }
        [HttpGet("Get All BookWithAuthorAndGener")]
        public IActionResult GetBookAuthorAll()
        {
            var all = _repo.GetBookAuthorAll();
            return Ok(all);
        }
        [HttpPut("update all")]
        public IActionResult UpdateBookAuthor(BookAuthorDto bookAuthorDto, int id)
        {
            _repo.UpdateBookAuthor(bookAuthorDto, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBookAuthor(int id)
        {
            _repo.DeleteBookAuthor(id);
            return NoContent();
        }

    }
}
