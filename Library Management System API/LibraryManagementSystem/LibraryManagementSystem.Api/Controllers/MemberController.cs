using AutoMapper;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Domain.ViewModels.Member;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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
    }
}