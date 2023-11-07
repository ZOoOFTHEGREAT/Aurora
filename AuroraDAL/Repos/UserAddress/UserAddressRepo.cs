using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserAddressRepo : GenericRepo<UserAddress>, IUserAddressRepo
{
    public UserAddressRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
