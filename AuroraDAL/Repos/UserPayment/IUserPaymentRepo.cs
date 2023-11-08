using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IUserPaymentRepo:IGenericRepo<UserPayment>
{
    UserPayment? GetUserPaymentByUserId(string UserId);
}
