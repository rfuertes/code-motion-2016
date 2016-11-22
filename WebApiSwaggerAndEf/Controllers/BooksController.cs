using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ejemploWebApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
{
    private BooksDataContext _booksDataContext;
    public BooksController(BooksDataContext booksDataContext)
    {
        _booksDataContext = booksDataContext;
    }
    [HttpGet]
    public IEnumerable<Book> Get()
    {
        return _booksDataContext.Books.AsEnumerable();
    }

    [HttpGet("{id}")]
    public Book Get(int id)
    {
        return _booksDataContext.Books.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost]
    public void Post([FromBody]Book book)
    {
        _booksDataContext.Add(book);
        _booksDataContext.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody]Book book)
    {
        var selectedBook = _booksDataContext.Books.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (selectedBook != null)
        {
            _booksDataContext.Entry(selectedBook).Context.Update(book);
            _booksDataContext.SaveChanges();
        }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var book = _booksDataContext.Books.FirstOrDefault(x => x.Id == id);
        if (book != null)
        {
            _booksDataContext.Books.Remove(book);
            _booksDataContext.SaveChanges();
        }
    }
}
}
