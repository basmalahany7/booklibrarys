namespace booklibrarys.Models
{
    public class Author
    {
       public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string PhoneNumber { get; set; }
        public string AuthorEmail { get; set; }
        public List<Book>Books { get; set; }

    }
}
