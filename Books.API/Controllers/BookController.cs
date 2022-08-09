using DBLayer;
using DBLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext _context;
        public BookController(BookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> ShowAllBooks()
        {
            if (_context.Books == null)
            {
                return NotFound("Table doesn't exists");
            }
            return await _context.Books.ToListAsync();
        }


        [HttpGet("{searchString}")]
        public async Task<IActionResult> Search(string searchString)
        {
            if (searchString == null)
            {
                return BadRequest("input can't be null");
            }
            if (_context.Books == null)
            {
                return NotFound("Table doesn't exists");
            }
            var books = await _context.Books.Where(b => b.Name.Contains(searchString) || b.Zoner.Contains(searchString)).ToListAsync();
            if (books == null)
            {
                return NotFound("Record doesn't exists");
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddOneBook(Book book)
        {
            if (book == null)
            {
                return BadRequest("Employee object can't be null");
            }
            if (_context.Books == null)
            {
                return NotFound("Table doesn't exists");
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOneBook(int Id, Book book)
        {
            if (book == null)
            {
                return BadRequest(" object can't be null");
            }
            if (_context.Books == null)
            {
                return NotFound("Table doesn't exists");
            }
            var bookToUpdate = await _context.Books.Where(e => e.Id == Id).FirstOrDefaultAsync();
            if (bookToUpdate == null)
            {
                return NotFound("Employee with this empId doesn't exists");
            }
            bookToUpdate.Name = book.Name;
            bookToUpdate.Zoner = book.Zoner;
            bookToUpdate.ReleaseDate = book.ReleaseDate;
            bookToUpdate.Cost = book.Cost;
            bookToUpdate.bookimg = book.bookimg;
           


            _context.Books.Update(bookToUpdate);
            await _context.SaveChangesAsync();
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOneBook(int Id)
        {
            if (_context.Books == null)
            {
                return NotFound("Table doesn't exists");
            }
            var bookToDelete = await _context.Books.Where(e => e.Id == Id).FirstOrDefaultAsync();
            if (bookToDelete == null)
            {
                return NotFound("Employee with this empId doesn't exists");
            }
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return Ok("Deleted Successfully");
        }
    }
}
