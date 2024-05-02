using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Repository.Base;
using LibraryManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class BorrowdBookRepository : BaseRepository<BorrowdBook>, IBorrowdBookRepository
    {
        public override async Task<IEnumerable<BorrowdBook>> GetAll()
        {
            var getBorrowdBooks = await _dbContext.BorrowdBooks
                                  .Include(bb => bb.Member)
                                  .Include(bb => bb.Book)
                                  .ToListAsync();

            return getBorrowdBooks;
        }
    }
}