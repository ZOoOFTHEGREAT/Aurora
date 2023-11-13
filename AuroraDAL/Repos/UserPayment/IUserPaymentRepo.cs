using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IUserPaymentRepo:IGenericRepo<UserPayment>
{
    IEnumerable<UserPayment>? GetUserPaymentByUserId(string UserId);
}
