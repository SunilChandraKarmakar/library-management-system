using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Manager.Base;
using LibraryManagementSystem.Manager.Contract;
using LibraryManagementSystem.Repository.Contract;

namespace LibraryManagementSystem.Manager
{
    public class BookManager : BaseManager<Book>, IBookManager
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }
    }
}