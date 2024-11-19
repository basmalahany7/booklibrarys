namespace booklibrarys.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }

        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
