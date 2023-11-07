using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserAddressRepo : GenericRepo<UserAddress>, IUserAddressRepo
{
    private readonly AppDbContext appDbContext;

    public UserAddressRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public UserAddress? GetUserAddresByUserId(int UserId) => appDbContext
        .Set<UserAddress>().FirstOrDefault(i=>i.UserId== UserId);
}
