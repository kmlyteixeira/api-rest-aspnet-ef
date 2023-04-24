using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(await _bookRepository.GetAll());
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookRepository.GetById(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            return Ok(book);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _bookRepository.Create(book);
            if (await _bookRepository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }

            return BadRequest("Error creating book");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Id's are not the same");
            }

            _bookRepository.Update(book);
            if (await _bookRepository.SaveChangesAsync())
            {
                return Ok(book);
            }

            return BadRequest("Error updating book");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound("Book not found");
            }

            _bookRepository.Delete(book);
            if (await _bookRepository.SaveChangesAsync())
            {
                return Ok("Book deleted");
            }

            return BadRequest("Error deleting book");
        }
    }
}