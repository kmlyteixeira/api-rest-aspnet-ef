using Models;

namespace Interfaces
{
    public interface IBookRepository
    {
        void Create(Book book);
        void Update(Book book);
        void Delete(Book book);
        Task<Book> GetById(int id);
        Task<IEnumerable<Book>> GetAll();
        Task<bool> SaveChangesAsync();
    }
}