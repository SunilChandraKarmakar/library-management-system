using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Repository.Base;
using LibraryManagementSystem.Repository.Contract;

namespace LibraryManagementSystem.Repository
{
    public class BorrowdBookRepository : BaseRepository<BorrowdBook>, IBorrowdBookRepository
    {
    }
}