using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserPaymentRepo : GenericRepo<UserPayment>, IUserPaymentRepo
{

    #region Inject
    private readonly AppDbContext appDbContext;

    public UserPaymentRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion

    #region Get User Payment By User Id
    public UserPayment? GetUserPaymentByUserId(string UserId)
    {
        return appDbContext.Set<UserPayment>().FirstOrDefault(i => i.UserId == UserId);
    }
    #endregion

}
