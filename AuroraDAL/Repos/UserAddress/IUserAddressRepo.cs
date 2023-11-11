using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IUserAddressRepo:IGenericRepo<UserAddress>
{
    List<UserAddress>? GetAddressesByUserId(string id);
}
