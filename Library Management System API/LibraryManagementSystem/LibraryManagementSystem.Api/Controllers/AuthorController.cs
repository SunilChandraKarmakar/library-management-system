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
        private readonly IMapper _mapper;

        public AuthorController(IAuthorManager authorManager, IMapper mapper)
        {
            _authorManager = authorManager;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuthorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> GetAll()
        {
            var getAuthors = _mapper.Map<IEnumerable<AuthorViewModel>>(await _authorManager.GetAll());
            return Ok(getAuthors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AuthorViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthorViewModel>> GetById(int? id)
        {
            if (id is null)
                return NotFound(new { ErrorMessage = "Author id was not found! Try Again." });

            var getAuthorById = _mapper.Map<AuthorViewModel>(await _authorManager.GetById(id));

            if (getAuthorById is null)
                return NotFound(new { ErrorMessage = "Author was not found! Try again." });

            return Ok(getAuthorById);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthorCreateModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<AuthorCreateModel>> Create([FromBody] AuthorCreateModel authorCreateModel)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<Author>(authorCreateModel);
                var isSave = await _authorManager.Create(author);
                _mapper.Map(author, authorCreateModel);

                if (isSave)
                    return Ok(authorCreateModel);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AuthorEditModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthorEditModel>> Update(int? id, AuthorEditModel authorEditModel)
        {
            if (id is null || id != authorEditModel.Id)
                return NotFound(new { ErrorMessage = "Author id was not found! Try again." });

            var existingAuthor = await _authorManager.GetById(id);

            if (ModelState.IsValid)
            {
                _mapper.Map(authorEditModel, existingAuthor);
                var isUpdate = await _authorManager.Update(existingAuthor);
                _mapper.Map(existingAuthor, authorEditModel);

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