using booklibrarys.DTOs.AuthorDtos;
using booklibrarys.Repo.AuthorRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace booklibrarys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _Repo;
        public AuthorController(IAuthorRepo repo)
        {
            _Repo = repo;
        }
        [HttpPost("Add AuthorBook")]
        public IActionResult AddAuthorBook(AuthorBookDto authorBookDto)
        {
            _Repo.AddAuthorBook(authorBookDto);
            return Created();
        }
        [HttpPost("Add AuthorOnly")]
        public IActionResult AddAuthor(AuthorDto authorDto)
        {
            _Repo.AddAuthorOnly(authorDto);
            return Created();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _Repo.GetById(id);
            return Ok(author);
        }
        [HttpGet("Get AllAuthorBook")]
        public IActionResult GetAll()
        {
           var all= _Repo.GetAll();
            return Ok(all);
        }
        [HttpPut("update Author Book")]
        public IActionResult UpdateAuthorBook(AuthorBookDto authorBookDto, int id)
        {
            _Repo.UpdateAuthorBook(authorBookDto, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
           _Repo.DeleteAuthorBook(id);
            return NoContent();
        }
    }
}
