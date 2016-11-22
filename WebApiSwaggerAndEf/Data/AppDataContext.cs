
using System;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

    }
    
    public class BooksDataContext : DbContext
    {
        public BooksDataContext(DbContextOptions<BooksDataContext> options)
            : base(options)
        {
        }
        
        public DbSet<Book> Books { get; set; }
    }
}