using Database;
using Interfaces;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
  public class BookRepository : IBookRepository
  {
    private readonly Context _context;

    public BookRepository(Context context)
    {
      _context = context;
    }

    void IBookRepository.Create(Book book)
    {
      _context.Books.Add(book);
    }

    void IBookRepository.Delete(Book book)
    {
      _context.Books.Remove(book);
    }

    async Task<IEnumerable<Book>> IBookRepository.GetAll()
    {
      var books = _context.Books.ToList();
      return await Task.FromResult(books);
    }

    async Task<Book> IBookRepository.GetById(int id)
    {
      var book = _context.Books.Where(b => b.Id == id).FirstOrDefault();
      return await Task.FromResult(book);
    }

    void IBookRepository.Update(Book book)
    {
      _context.Entry(book).State = EntityState.Modified;
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}