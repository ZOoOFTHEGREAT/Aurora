using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;
public class CartItemRepo : GenericRepo<CartItem>, ICartItemRepo
{
    private readonly AppDbContext appDbContext;

    public CartItemRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public List<CartItem>? GetCartItemByCartId(int id)
    {
        return appDbContext.Set<CartItem>().Where(x => x.CartId == id).ToList();
    }
}
