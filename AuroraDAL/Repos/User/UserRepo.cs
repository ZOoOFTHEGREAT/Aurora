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
             => appDbContext.Set<User>().FirstOrDefault(i => i.PhoneNumber == phoneNumber);

    public User? GetUSerByEmail(string email)
             => appDbContext.Set<User>().FirstOrDefault(i => i.Email == email);

}
