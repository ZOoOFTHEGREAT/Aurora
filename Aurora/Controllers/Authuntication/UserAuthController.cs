using AuroraAPI.Services.Email;
using AuroraBLL;
using AuroraBLL.Dtos.Authuntication;
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
        private readonly IMailService mailService;

        public UserAuthController(UserManager<User> userManager,IGenerateToken generatedToken,IMailService mailService)
        {
            this.userManager = userManager;
            this.generatedToken = generatedToken;
            this.mailService = mailService;
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
            await mailService.SendEmailAsync(userDto.Email, "Welcome To Aurora", $"Hi {userDto.Fname}+{userDto.Lname} Welcome To our Website");

            return userDto;
        }

        [HttpPut]
        public async Task<ActionResult<UpdateUserDto>> UpdateUserData(UpdateUserDto userToUpdate)
        {
            if (userToUpdate == null)
                return BadRequest();
            var usr = await userManager.FindByIdAsync(userToUpdate.Id);
            if (usr == null)
                return BadRequest();

            usr!.UserName = userToUpdate.UserName;
            usr!.Fname = userToUpdate.Fname;
            usr!.Lname = userToUpdate.Lname;
            usr!.Email = userToUpdate.Email;
            usr!.PhoneNumber = userToUpdate.PhoneNumber;
            usr!.ZipCode = userToUpdate.ZipCode;

            var result = await userManager.UpdateAsync(usr);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(userToUpdate);
        }
        [HttpPut]
        [Route("updatepw")]
        public async Task<ActionResult<ChangePwDto>> UpdateUserPw(ChangePwDto pwDto)
        {
            if (pwDto == null)
                return NotFound();
            var usr = await userManager.FindByIdAsync(pwDto.Id);
            if (usr == null)
                return NotFound();
            if (string.IsNullOrEmpty(pwDto.OldPassword))
                return BadRequest();
            var oldUserPwCheck = await userManager.CheckPasswordAsync(usr, pwDto.OldPassword);
            if (!oldUserPwCheck)
                return Unauthorized();
            if (!string.IsNullOrEmpty(pwDto.Password))
            {
                var changePasswordResult = await userManager.ChangePasswordAsync(usr, pwDto.OldPassword, pwDto.Password);

                if (!changePasswordResult.Succeeded)
                {
                    return BadRequest();
                }
            }
            return Ok();
        }


    }
}
