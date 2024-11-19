using booklibrarys.DTOs.AuthorDtos;

namespace booklibrarys.Repo.AuthorRepos
{
    public interface IAuthorRepo
    {
        public List<AuthorBookDto> GetAll();
        public AuthorBookDto GetById(int id);
        public void AddAuthorOnly(AuthorDto authorDto);
        public void AddAuthorBook(AuthorBookDto authorBookDto);
        public void UpdateAuthorBook(AuthorBookDto authorBookDto,int id);
        public void DeleteAuthorBook(int id);
    }
}
