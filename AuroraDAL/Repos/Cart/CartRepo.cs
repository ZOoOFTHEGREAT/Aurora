using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class CartRepo : GenericRepo<Cart>, ICartRepo
{
    #region Inject
    private readonly AppDbContext appDbContext;

    public CartRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion

    #region Get Cart By User Id 
    public Cart? GetCartByUserId(string UserID)
    {
        return appDbContext.Set<Cart>().Find(UserID);
    }
    #endregion

}
