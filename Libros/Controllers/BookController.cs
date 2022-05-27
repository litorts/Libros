using Libros.DataService;
using Libros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            IEnumerable<Book> books = new List<Book>();
            try
            {
                books = BooksDataService.GetAll();
            }
            catch
            {
                books = new List<Book>();
                return BadRequest(new Response2(books, "error"));
            }
            return Ok(new Response2(books, "success"));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public ActionResult<Response> GetById(long id)
        {
            var book = new Book();
            try
            {
                book = BooksDataService.GetById(id);
            }
            catch
            {
                return BadRequest(new Response(new Book(), "error"));
            }
            return Ok(new Response(book, "succes"));
        }
        [HttpGet("title/{title}")]
        public ActionResult<Response2> GetByTitle(string title)
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                book = BooksDataService.GetByTitle(title);
            }
            catch
            {
                return BadRequest(new Response2(new List<Book>(), "error"));
            }
            return Ok(new Response2(book, "success"));
        }
        [HttpGet("editorial/{editorial}")]
        public ActionResult<Response2> GetByEditorial(string editorial)
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                book = BooksDataService.GetByEditorial(editorial);
            }
            catch
            {
                return BadRequest(new Response2(new List<Book>(), "success"));
            }
            return Ok(new Response2(book, "success"));
        }
        [HttpGet("author/{author}")]
        public ActionResult<Response2> GetByAuthor(string author)
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                book = BooksDataService.GetByAuthor(author);
            }
            catch
            {
                return BadRequest(new Response2(new List<Book>(), "success"));
            }
            return Ok(new Response2(book, "success"));
        }
        [HttpGet("location/{location}")]
        public ActionResult<Response2> GetByLocation(string location)
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                book = BooksDataService.GetByLocation(location);
            }
            catch
            {
                return BadRequest(new Response2(new List<Book>(), "success"));
            }
            return Ok(new Response2(book, "success"));
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult<Response> Post([FromBody] Book book)
        {
            try
            {
                if (book.Validate())
                {
                    var id = BooksDataService.Add(book);
                    book.Id = id;
                    return Ok(new Response(book, $"Book '{book.Title}' Created succesfull."));
                }
                else
                {
                    return BadRequest(new Response(book, $"Error Creating book '{book.Title}'. book no validate."));
                }
                
            }
            catch
            {
                return BadRequest(new Response(book, $"Error creating book '{book.Title}'."));
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public ActionResult<Response> Put(int id, [FromBody] Book book)
        {
            var ret = new ActionResult<Response>(new Response(book, ""));
            try
            {
                if (book.Validate())
                {
                    book.Id = id;
                    var newBook = BooksDataService.Edit(book);
                    ret = Ok(new Response(book, $"Book '{newBook.Title}' Edited succesfull."));
                }
                else
                {
                    ret = BadRequest(new Response(book, $"Error Editing book '{book.Title}'. book no validate."));
                }
            }
            catch
            {
                ret =  BadRequest(new Response(book, $"Error editing book '{book.Title}'."));
            }
            return ret;
        }
        [HttpGet("TestConenction")]
        public ActionResult<string> TestConnection()
        {
            return Ok(BooksDataService.TestConnection());
        }
    }
}
