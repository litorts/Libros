namespace Libros.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Editorial { get; set; }
        public string Location { get; set; }
        public bool Validate()
        {
            if(Title != null && Author != null) return true;
            return false;
        }
    }
}
