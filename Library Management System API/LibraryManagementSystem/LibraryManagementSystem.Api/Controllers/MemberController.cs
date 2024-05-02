using AutoMapper;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Domain.ViewModels.Member;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public MemberController(UserManager<Member> userManager, SignInManager<Member> signInManager, IMapper mapper, 
            IOptions<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtConfig = jwtConfig.Value;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MemberViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MemberViewModel>>> GetAll()
        {
            var getMembers = _mapper.Map<IEnumerable<MemberViewModel>>
                (await _userManager.Users.Include(u => u.MemberType).ToListAsync());

            return Ok(getMembers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MemberViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MemberViewModel>> GetById(string? id)
        {
            if (id is null)
                return NotFound(new { ErrorMessage = "Member id was not found! Try Again." });

            var getMemberById = _mapper.Map<MemberViewModel>(await _userManager.FindByIdAsync(id));

            if (getMemberById is null)
                return NotFound(new { ErrorMessage = "Member was not found! Try again." });

            return Ok(getMemberById);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MemberCreateModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<MemberCreateModel>> Create([FromBody] MemberCreateModel memberCreateModel)
        {
            if (ModelState.IsValid)
            {               
                var member = _mapper.Map<Member>(memberCreateModel);
                member.UserName = memberCreateModel.Email;

                var result = await _userManager.CreateAsync(member, memberCreateModel.Password);
                var createdMember = _mapper.Map<MemberCreateModel>(member);

                if (result.Succeeded)
                    return Ok(createdMember);
                else
                    return BadRequest(result.Errors.Select(s => s.Description).ToArray());
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MemberEditModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MemberEditModel>> Update(string? id, MemberEditModel memberEditModel)
        {
            if (id is null || id != memberEditModel.Id)
                return NotFound(new { ErrorMessage = "Member id was not found! Try again." });

            var existingMember = await _userManager.FindByIdAsync(id);

            if (existingMember is null)
                return NotFound(new { ErrorMessage = "Member was not found! Try again." });

            if (ModelState.IsValid)
            {
                existingMember.FirstName = memberEditModel.FirstName;
                existingMember.LastName = memberEditModel.LastName;
                existingMember.Email = memberEditModel.Email;
                existingMember.PhoneNumber = memberEditModel.PhoneNumber;
                existingMember.PasswordHash = memberEditModel.Password;
                existingMember.MemberTypeId = memberEditModel.MemberTypeId;
                existingMember.RegistrationDate = memberEditModel.RegistrationDate;
                existingMember.UserName = memberEditModel.Email;

                var result = await _userManager.UpdateAsync(existingMember);
                var updateMember = _mapper.Map<MemberEditModel>(existingMember);

                if (result.Succeeded)
                    return Ok(updateMember);

                return BadRequest(result.Errors.Select(s => s.Description).ToArray());
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(string? id)
        {
            if (id is null)
                return NotFound(new { ErrorMessage = "Member id was not found! Try again." });

            var existingMember = await _userManager.FindByIdAsync(id);
            if (existingMember is null)
                return NotFound(new { ErrorMessage = "Member was not found! Try again." });

            var isDelete = await _userManager.DeleteAsync(existingMember);
            if (isDelete.Succeeded)
                return Ok(true);

            return BadRequest(new { ErrorMessage = "Member was not delete! Try again." });
        }
    }
}