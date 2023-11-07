using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;
public class CartItemRepo : GenericRepo<CartItem>, ICartItemRepo
{
    #region Inject
    private readonly AppDbContext appDbContext;

    public CartItemRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion

    #region Get Cart Item By Cart Id 
    public List<CartItem>? GetCartItemByCartId(int CartId)
    {
        return appDbContext.Set<CartItem>().Where(x => x.CartId == CartId).ToList();
    }
    #endregion
}
