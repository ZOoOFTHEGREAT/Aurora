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
        ReadUserPaymentDetailDto GetById(int Id);
        //list 
        List<ReadUserPaymentByUserIdDto>? GetUserPaymentByUserId(string userId);
        bool IsDeleted(int userPaymentId);
    }
}
