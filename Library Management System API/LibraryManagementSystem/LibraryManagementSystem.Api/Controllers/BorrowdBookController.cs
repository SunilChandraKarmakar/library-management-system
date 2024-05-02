using AutoMapper;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Domain.ViewModels.BorrowdBook;
using LibraryManagementSystem.Manager.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BorrowdBookController : ControllerBase
    {
        private readonly IBorrowBookManager _borrowBookManager;
        private readonly IMapper _mapper;

        public BorrowdBookController(IBorrowBookManager borrowBookManager, IMapper mapper)
        {
            _borrowBookManager = borrowBookManager;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BorrowdBookViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BorrowdBookViewModel>>> GetAll()
        {
            var getBorrowdBooks = _mapper.Map<IEnumerable<BorrowdBookViewModel>>(await _borrowBookManager.GetAll());
            return Ok(getBorrowdBooks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BorrowdBookViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BorrowdBookViewModel>> GetById(int? id)
        {
            if (id is null)
                return NotFound(new { ErrorMessage = "Borrowd book id was not found! Try Again." });

            var getBorrowdBookById = _mapper.Map<BorrowdBookViewModel>(await _borrowBookManager.GetById(id));

            if (getBorrowdBookById is null)
                return NotFound(new { ErrorMessage = "Borrowd book was not found! Try again." });

            return Ok(getBorrowdBookById);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BorrowdBookCreateModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<BorrowdBookCreateModel>> Create([FromBody] BorrowdBookCreateModel borrowdBookCreateModel)
        {
            if (ModelState.IsValid)
            {
                var borrowdBook = _mapper.Map<BorrowdBook>(borrowdBookCreateModel);
                var isSave = await _borrowBookManager.Create(borrowdBook);
                _mapper.Map(borrowdBook, borrowdBookCreateModel);

                if (isSave)
                    return Ok(borrowdBookCreateModel);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BorrowdBookEditModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BorrowdBookEditModel>> Update(int? id, BorrowdBookEditModel borrowdBookEditModel)
        {
            if (id is null || id != borrowdBookEditModel.Id)
                return NotFound(new { ErrorMessage = "Borrowd book id was not found! Try again." });

            var existingBorrowdBook = await _borrowBookManager.GetById(id);

            if (ModelState.IsValid)
            {
                _mapper.Map(borrowdBookEditModel, existingBorrowdBook);
                var isUpdate = await _borrowBookManager.Update(existingBorrowdBook);
                _mapper.Map(existingBorrowdBook, borrowdBookEditModel);

                if (isUpdate)
                    return Ok(borrowdBookEditModel);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if (id is null)
                return NotFound(new { ErrorMessage = "Borrowd book id was not found! Try again." });

            var existingBorrowdBook = await _borrowBookManager.GetById(id);
            if (existingBorrowdBook is null)
                return NotFound(new { ErrorMessage = "Borrowd book was not found! Try again." });

            var isDelete = await _borrowBookManager.Delete(existingBorrowdBook);
            if (isDelete)
                return Ok(true);

            return BadRequest(new { ErrorMessage = "Borrowd book was not delete! Try again." });
        }
    }
}