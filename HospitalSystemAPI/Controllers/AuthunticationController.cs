using HospitalCareSystem.BL;
using HospitalCareSystem.DAL.Data.Models;
using HospitalSystemAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalCareSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthunticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;

        public AuthunticationController(IConfiguration configuration,UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var usr = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Department = registerDto.Department
            };
            var creationResult = await userManager.CreateAsync(usr,registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }

            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.NameIdentifier, usr.Id),
                new Claim (ClaimTypes.Role,registerDto.Role),
                new Claim ("Nationality",registerDto.Nationality)
            };
            await userManager.AddClaimsAsync(usr, claims);

            return NoContent();
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {
            User? userExist = await userManager.FindByNameAsync(loginDto.UserName);
            if (userExist == null)
            {
                return Unauthorized();
            }
            var checkPw = await userManager.CheckPasswordAsync(userExist, loginDto.Password);
            if (checkPw == false) return Unauthorized();

            var x = await userManager.AccessFailedAsync(userExist);

            var expire = DateTime.Now.AddMinutes(10);

            var claimList = await userManager.GetClaimsAsync(userExist);
            var secretKey = configuration.GetValue<string>("SecretKey");
            var algorithm = SecurityAlgorithms.HmacSha256Signature;
            var keyInBytes = Encoding.ASCII.GetBytes(secretKey!);
            var keySymetricSecKey = new SymmetricSecurityKey(keyInBytes);
            var siginingCred = new SigningCredentials(keySymetricSecKey, algorithm);
            var token = new JwtSecurityToken(claims: claimList,
                signingCredentials: siginingCred,
                expires:expire
                );
            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenDto
            {
                Token = tokenHandler.WriteToken(token),
                ExpireDate = expire
            };

        }

        [HttpGet]
        [Authorize]
        [Route("doc")]
        public ActionResult GetAll()
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult<TokenDto> LoginStatic(LoginDto loginDto)
        {
            if (loginDto.UserName != "admin" && loginDto.Password != "123")
            {
                return Unauthorized();
            }
                var claimsList = new List<Claim>
                { new Claim (ClaimTypes.NameIdentifier ,Guid.NewGuid().ToString()),
                  new Claim (ClaimTypes.Role,"Admin"),
                  new Claim ("Nationlity","Egyptian")
                };

            var exp = DateTime.Now.AddMinutes(10);
                var secretKey = configuration.GetValue<string>("SecretKey");
                var algorithm = SecurityAlgorithms.HmacSha256Signature;
                var keyInBytes = Encoding.ASCII.GetBytes(secretKey!);
                var keySymetricSecKey = new SymmetricSecurityKey(keyInBytes);
                var siginingCred = new SigningCredentials(keySymetricSecKey,algorithm);
                var token = new JwtSecurityToken(claims: claimsList, 
                    signingCredentials: siginingCred,
                    expires:exp
                    );
                var tokenHandler = new JwtSecurityTokenHandler();
                
                return new TokenDto
                {
                    Token = tokenHandler.WriteToken(token),
                    ExpireDate = exp
                };
        }
    }
}
