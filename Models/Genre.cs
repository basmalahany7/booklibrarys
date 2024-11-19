namespace booklibrarys.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
