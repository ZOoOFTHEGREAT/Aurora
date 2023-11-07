using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class CartRepo : GenericRepo<Cart>, ICartRepo
{
    public CartRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
