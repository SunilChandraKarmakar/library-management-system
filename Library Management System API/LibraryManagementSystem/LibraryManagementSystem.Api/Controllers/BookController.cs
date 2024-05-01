using AutoMapper;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Domain.ViewModels.Book;
using LibraryManagementSystem.Manager.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        private readonly IMapper _iMapper;

        public BookController(IBookManager bookManager, IMapper iMapper)
        {
            _bookManager = bookManager;
            _iMapper = iMapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> GetAll()
        {
            var getBooks = _iMapper.Map<IEnumerable<BookViewModel>>(await _bookManager.GetAll());
            return Ok(getBooks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BookViewModel>> GetById(int? id)
        {
            if (id == null)
                return NotFound(new { ErrorMessage = "Book id was not found! Try Again." });

            var getBookById = _iMapper.Map<BookViewModel>(await _bookManager.GetById(id));

            if (getBookById == null)
                return NotFound(new { ErrorMessage = "Book was not found! Try again." });

            return Ok(getBookById);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookCreateModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<BookCreateModel>> Create([FromBody] BookCreateModel bookCreateModel)
        {
            if (ModelState.IsValid)
            {
                var book = _iMapper.Map<Book>(bookCreateModel);
                var isSave = await _bookManager.Create(book);
                _iMapper.Map(book, bookCreateModel);

                if (isSave)
                    return Ok(bookCreateModel);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BookEditModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BookEditModel>> Update(int? id, BookEditModel bookEditModel)
        {
            if (id is null || id != bookEditModel.Id)
                return NotFound(new { ErrorMessage = "Book id was not found! Try again." });

            var existingBook = await _bookManager.GetById(id);

            if (ModelState.IsValid)
            {
                _iMapper.Map(bookEditModel, existingBook);
                var isUpdate = await _bookManager.Update(existingBook);
                _iMapper.Map(existingBook, bookEditModel);

                if (isUpdate)
                    return Ok(bookEditModel);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if (id is null)
                return NotFound(new { ErrorMessage = "Book id was not found! Try again." });

            var existingBook = await _bookManager.GetById(id);
            if (existingBook is null)
                return NotFound(new { ErrorMessage = "Book was not found! Try again." });

            var isDelete = await _bookManager.Delete(existingBook);
            if (isDelete)
                return Ok(true);

            return BadRequest(new { ErrorMessage = "Book was not delete! Try again." });
        }
    }
}