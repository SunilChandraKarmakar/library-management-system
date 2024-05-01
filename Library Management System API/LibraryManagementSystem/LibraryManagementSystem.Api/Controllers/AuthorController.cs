using AutoMapper;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Domain.ViewModels.Author;
using LibraryManagementSystem.Manager.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager _authorManager;
        private readonly IMapper _iMapper;

        public AuthorController(IAuthorManager authorManager, IMapper iMapper)
        {
            _authorManager = authorManager;
            _iMapper = iMapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuthorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> GetAll()
        {
            var getAuthors = _iMapper.Map<ICollection<AuthorViewModel>>(await _authorManager.GetAll());
            return Ok(getAuthors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AuthorViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthorViewModel>> GetById(int? id)
        {
            if (id == null)
                return NotFound(new { ErrorMessage = "Author id was not found! Try Again." });

            var getAuthorById = _iMapper.Map<AuthorViewModel>(await _authorManager.GetById(id));

            if (getAuthorById == null)
                return NotFound(new { ErrorMessage = "Author was not found! Try again." });

            return Ok(getAuthorById);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthorCreateModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<AuthorCreateModel>> Post([FromBody] AuthorCreateModel authorCreateModel)
        {
            if (ModelState.IsValid)
            {
                var author = _iMapper.Map<Author>(authorCreateModel);
                var isSave = await _authorManager.Create(author);
                _iMapper.Map(author, authorCreateModel);

                if (isSave)
                    return Ok(authorCreateModel);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AuthorEditModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthorEditModel>> Put(int? id, AuthorEditModel authorEditModel)
        {
            if (id is null || id != authorEditModel.Id)
                return NotFound(new { ErrorMessage = "Author id was not found! Try again." });

            var existingAuthor = await _authorManager.GetById(id);

            if (ModelState.IsValid)
            {
                _iMapper.Map(authorEditModel, existingAuthor);
                var isUpdate = await _authorManager.Update(existingAuthor);
                _iMapper.Map(existingAuthor, authorEditModel);

                if (isUpdate)
                    return Ok(authorEditModel);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if (id is null)
                return NotFound(new { ErrorMessage = "Author id was not found! Try again." });

            var existingAuthor = await _authorManager.GetById(id);
            if (existingAuthor is null)
                return NotFound(new { ErrorMessage = "Author was not found! Try again." });

            var isDelete = await _authorManager.Delete(existingAuthor);
            if (isDelete)
                return Ok(true);

            return BadRequest(new { ErrorMessage = "Author was not delete! Try again." });
        }
    }
}