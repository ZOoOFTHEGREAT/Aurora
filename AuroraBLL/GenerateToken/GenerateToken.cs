using AuroraBLL.Dtos.AuthunticationDtos;
using AuroraBLL.Dtos.UserDtos;
using AuroraDAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuroraBLL;

public class GenerateToken : IGenerateToken
{
    private readonly IConfiguration configuration;
    private readonly User user;
    private readonly UserManager<User> userManager;

    public GenerateToken(IConfiguration configuration,User user,UserManager<User> userManager)
    {
        this.configuration = configuration;
        this.user = user;
        this.userManager = userManager;
    }

    public User FillUser(AddUserDto userDto)
    {
        user.UserName = userDto.UserName;
        user.Fname = userDto.Fname;
        user.Lname = userDto.Lname;
        user.Email = userDto.Email;
        user.PasswordHash = userDto.PasswordHash;
        user.PhoneNumber = userDto.PhoneNumber;
        user.ZipCode = userDto.ZipCode;
        return user;
    }
 
    public TokenDto Token(IList<Claim> claimList)
    {
        var secretKey = configuration.GetValue<string>("SecretKey");
        var algorithm = SecurityAlgorithms.HmacSha256Signature;
        var keyInByte = Encoding.ASCII.GetBytes(secretKey!);
        var key = new SymmetricSecurityKey(keyInByte);
        var siginingCred = new SigningCredentials(key, algorithm);
        var exp = DateTime.Now.AddMinutes(10);
        var token = new JwtSecurityToken(
            claims: claimList,
            expires: exp,
            signingCredentials: siginingCred);
        var tokenHandler = new JwtSecurityTokenHandler();

        return new TokenDto
        {
            Token = tokenHandler.WriteToken(token),
            ExpireDate = exp
        };
    }

}
