using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Repository.Base;
using LibraryManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public override async Task<IEnumerable<Book>> GetAll()
        {
            var books = await _dbContext.Books
                       .Include(c => c.Author)
                       .ToListAsync();

            return books;
        }
    }
}