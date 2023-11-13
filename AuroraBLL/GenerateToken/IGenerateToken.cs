using AuroraBLL.Dtos.AuthunticationDtos;
using AuroraBLL.Dtos.UserDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL;

public interface IGenerateToken
{
    public TokenDto Token(IList<Claim> claimList);

    public User FillUser(AddUserDto userDto);

}
