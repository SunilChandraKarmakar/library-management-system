using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Manager.Base;
using LibraryManagementSystem.Manager.Contract;
using LibraryManagementSystem.Repository.Contract;

namespace LibraryManagementSystem.Manager
{
    public class BorrowdBookManager : BaseManager<BorrowdBook>, IBorrowBookManager
    {
        private readonly IBorrowdBookRepository _borrowdBookRepository;

        public BorrowdBookManager(IBorrowdBookRepository borrowdBookRepository) : base(borrowdBookRepository)
        {
            _borrowdBookRepository = borrowdBookRepository;
        }
    }
}