using Libros.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Libros.DataService
{
    public class BooksDataService
    {
        public static string GetConnectionString()
        {
            return @"Server= localhost; Database= Books; Integrated Security=True;";
        }
        public static IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                using(SqlConnection sql = new SqlConnection(GetConnectionString()))
                {
                    sql.Open();
                    var results = sql.Query<Book>("GetAll", commandType: CommandType.StoredProcedure);
                    book = results;
                    sql.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[Exception][BookDataService][GetAll]Message: {ex.Message}");
                book = new List<Book>();
            }
            return book;
        }
        public static Book GetById(long id)
        {
            var book = new Book();
            try
            {
                using (SqlConnection sql = new SqlConnection(GetConnectionString()))
                {
                    var param = new DynamicParameters(); param.Add("id", id);
                    sql.Open();
                    var results = sql.Query<Book>("GetById", param, commandType: CommandType.StoredProcedure);
                    book = results.FirstOrDefault();
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception][BookDataService][GetById]Message: {ex.Message}");
                book = new Book();
            }
            return book;
        }
        public static IEnumerable<Book> GetByTitle(string name)
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                using (SqlConnection sql = new SqlConnection(GetConnectionString()))
                {
                    var param = new DynamicParameters(); param.Add("Title", name);
                    sql.Open();
                    var results = sql.Query<Book>("GetByTitle", param, commandType: CommandType.StoredProcedure);
                    book = results;
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception][BookDataService][GetByTitle]Message: {ex.Message}");
                book = new List<Book>();
            }
            return book;
        }
        public static IEnumerable<Book> GetByEditorial(string editorial)
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                using (SqlConnection sql = new SqlConnection(GetConnectionString()))
                {
                    var param = new DynamicParameters(); param.Add("Editorial", editorial);
                    sql.Open();
                    var results = sql.Query<Book>("GetByEditorial", param, commandType: CommandType.StoredProcedure);
                    book = results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception][BookDataService][GetByEditorial]Message: {ex.Message}");
                book = new List<Book>();
            }
            return book;
        }
        public static IEnumerable<Book> GetByAuthor(string author)
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                using (SqlConnection sql = new SqlConnection(GetConnectionString()))
                {
                    var param = new DynamicParameters(); param.Add("Author", author);
                    sql.Open();
                    var results = sql.Query<Book>("GetByAuthor", param, commandType: CommandType.StoredProcedure);
                    book = results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception][BookDataService][GetByAuthor]Message: {ex.Message}");
                book = new List<Book>();
            }
            return book;
        }
        public static IEnumerable<Book> GetByLocation(string location)
        {
            IEnumerable<Book> book = new List<Book>();
            try
            {
                using (SqlConnection sql = new SqlConnection(GetConnectionString()))
                {
                    var param = new DynamicParameters(); param.Add("Location", location);
                    sql.Open();
                    var results = sql.Query<Book>("GetByLocation", param, commandType: CommandType.StoredProcedure);
                    book = results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception][BookDataService][GetByLocation]Message: {ex.Message}");
                book = new List<Book>();
            }
            return book;
        }
        public static long Add(Book book)
        {
            long ret = 0;
            try
            {
                using (SqlConnection sql = new SqlConnection(GetConnectionString()))
                {
                    var param = new DynamicParameters();
                    param.Add("Title", book.Title);
                    param.Add("Author", book.Author);
                    if(book.Location != null) param.Add("Location", book.Location);
                    if (book.Editorial != null) param.Add("Editorial", book.Editorial);
                    sql.Open();
                    var results = sql.Query<long>("AddBook", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    ret = results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception][BookDataService][Add]Message: {ex.Message}");
                ret = 0;
            }
            return ret;
        }
        public static Book Edit(Book book)
        {
            var ret = new Book();
            try
            {
                using (SqlConnection sql = new SqlConnection(GetConnectionString()))
                {
                    var param = new DynamicParameters();
                    param.Add("Id", book.Id);
                    param.Add("Title", book.Title);
                    param.Add("Author", book.Author);
                    if (book.Location != null) param.Add("Location", book.Location);
                    if (book.Editorial != null) param.Add("Editorial", book.Editorial);
                    sql.Open();
                    var results = sql.Query<Book>("EditBook", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    ret = results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception][BookDataService][Edit]Message: {ex.Message}");
                ret = new Book();
            }
            return ret;
        }
        public static string TestConnection()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(GetConnectionString()))
                {
                    cn.Open();
                    return cn.State.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
