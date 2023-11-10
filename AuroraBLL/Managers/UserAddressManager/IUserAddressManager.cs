using AuroraBLL.Dtos.UserAddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.UserAddressManager
{
    public interface IUserAddressManager
    {
        int Add(AddUserAddressDto addUserAddressDto);
        List<ReadUserAddressDto> GetAll();
        ReadUserAddresByUserIdDto GetAddressByUserId(string userId);
        ReadUserAddressDetailDto GetById(ReadUserAddressDetailDto readUserAddressDetailDto);
        bool IsUpdated(UpdateUserAddressDto updateUserAddressDto);
        bool IsDeleted(DeleteUserAddressDto deleteUserAddressDto);
    }
}
