using AutoMapper;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Domain.ViewModels.Login;
using LibraryManagementSystem.Domain.ViewModels.Member;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public AuthenticationController(UserManager<Member> userManager, SignInManager<Member> signInManager, IMapper mapper, 
            IOptions<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtConfig = jwtConfig.Value;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MemberViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MemberViewModel>> Login([FromBody] LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);

                if (result.Succeeded)
                {
                    var getExistMember = await _userManager.Users
                                       .Include(u => u.MemberType)
                                       .Where(u => u.Email.ToLower() == loginModel.Email.ToLower())
                                       .FirstOrDefaultAsync();

                    var mapExistMember = _mapper.Map<MemberViewModel>(getExistMember);
                    mapExistMember.Token = GenerateToken(mapExistMember);

                    return Ok(mapExistMember);
                }

                return BadRequest("Email and Password can not match, try again.");
            }

            return BadRequest(ModelState);
        }

        private string GenerateToken(MemberViewModel memberViewModel)
        {
            var jwtTokenHendler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtConfig.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId, memberViewModel.Id),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, memberViewModel.Email),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };

            var token = jwtTokenHendler.CreateToken(tokenDescriptor);
            return jwtTokenHendler.WriteToken(token);
        }
    }
}