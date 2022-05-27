using System.Collections.Generic;

namespace Libros.Models
{
    public class Response
    {
        public Book Book { get; set; }
        public string Message { get; set; }
        public Response(Book book, string mess)
        {
            Book = book;
            Message = mess;
        }
    }
    public class Response2
    {
        public IEnumerable<Book> Book { get; set; }
        public string Message { get; set; }
        public Response2(IEnumerable<Book> book, string mess)
        {
            Book = book;
            Message = mess;
        }
    }
}
