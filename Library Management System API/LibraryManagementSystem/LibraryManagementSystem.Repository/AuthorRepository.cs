using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Repository.Base;
using LibraryManagementSystem.Repository.Contract;

namespace LibraryManagementSystem.Repository
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
    }
}