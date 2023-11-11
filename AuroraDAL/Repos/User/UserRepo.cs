using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserRepo : GenericRepo<User>, IUserRepo
{
    #region Inject IUnit Of Work
    private readonly AppDbContext appDbContext;

    public UserRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion
    public User GetUserById(string Id) => appDbContext.Set<User>().Find(Id)!;

    public User? GetUSerByPhoneNumber(string phoneNumber)
    {
        User user = (User)appDbContext.Users.Where(x => x.PhoneNumber == phoneNumber);
        return user;
    }
    public User? GetUSerByEmail(string email)
    {
        User user = (User)appDbContext.Users.Where(x => x.Email == email);
        return user;
    }
}
