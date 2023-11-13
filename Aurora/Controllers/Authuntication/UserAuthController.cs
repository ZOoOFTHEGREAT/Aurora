using AuroraBLL;
using AuroraBLL.Dtos.AuthunticationDtos;
using AuroraBLL.Dtos.UserDtos;
using AuroraDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;

namespace AuroraAPI.Controllers.Authuntication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IGenerateToken generatedToken;

        public UserAuthController(UserManager<User> userManager,IGenerateToken generatedToken)
        {
            this.userManager = userManager;
            this.generatedToken = generatedToken;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user is null)
                return Unauthorized();

            var userPw = await userManager.CheckPasswordAsync(user,loginDto.Password);
            if (!userPw)
                return Unauthorized();

            await userManager.AccessFailedAsync(user);

            var claimList = await userManager.GetClaimsAsync(user);

            var token = generatedToken.Token(claimList);

            return token;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<AddUserDto>> Register(AddUserDto userDto)
        {
            if (userDto == null)
                return BadRequest();

             var user = generatedToken.FillUser(userDto);        
      
            var userCreation = await userManager.CreateAsync(user,userDto.PasswordHash);
            if (!userCreation.Succeeded)
                return BadRequest();

            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id),
                new Claim(ClaimTypes.Role,userDto.Role!)
            };

            await userManager.AddClaimsAsync(user,claimList);

            return userDto;
        }
    }
}
