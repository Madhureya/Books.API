using DBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public  class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<AddCart> Cart { set; get; }
        public BookDbContext()  { }
        public BookDbContext(DbContextOptions options)
        : base(options)
        {

        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HP-NOTEBOOK;Initial Catalog=BooksDb;Integrated Security=True");
        }
       
        }
    }

