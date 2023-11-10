using AuroraBLL.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.UserManager
{
    public interface IUserManger
    {
        int Add(AddUserDto user);
        List<ReadAllUserDto> GetAllUsers();
        ReadUserByIdDto GetUserById(string id);
        ReadUserDetailsByIdDto GetUserDetailsById(string id);
        bool IsUpdated(UpdateUserDto user);
        bool IsDeleted(DeleteUserDto user);
    }
}
