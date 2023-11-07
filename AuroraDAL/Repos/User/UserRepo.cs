using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserRepo : GenericRepo<User>, IUserRepo
{
    public UserRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
