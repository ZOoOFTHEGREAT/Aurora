using AuroraBLL.Dtos.UserPaymentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.UserPaymentManager
{
    public interface IUserPaymentManager
    {
        int Add(AddUserPaymentDto addUserPaymentDto);
        List<ReadUserPaymentDto> GetAll();
        ReadUserPaymentDetailDto GetById(ReadUserPaymentDetailDto Id);
        ReadUserPaymentByUserIdDto GetUserPaymentByUserId(ReadUserPaymentByUserIdDto readUserPaymentByUserIdDto);
        bool IsUpdated(UpdateUserPaymentDto updateUserPaymentDto);
        bool IsDeleted(DeleteUserPaymentDto deleteUserPaymentDto); 
    }
}
