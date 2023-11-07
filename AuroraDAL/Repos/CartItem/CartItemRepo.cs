using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;
public class CartItemRepo : GenericRepo<CartItem>, ICartItemRepo
{
    public CartItemRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
