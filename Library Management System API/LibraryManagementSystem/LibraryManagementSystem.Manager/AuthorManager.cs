using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Manager.Base;
using LibraryManagementSystem.Manager.Contract;
using LibraryManagementSystem.Repository.Contract;

namespace LibraryManagementSystem.Manager
{
    public class AuthorManager : BaseManager<Author>, IAuthorManager
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository) : base(authorRepository)
        {
            _authorRepository = authorRepository;
        }
    }
}