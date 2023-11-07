using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class CartRepo : GenericRepo<Cart>, ICartRepo
{
    private readonly AppDbContext appDbContext;

    public CartRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public List<Cart>? GetCartByUserId(int id)
    {
        return appDbContext.Set<Cart>().Where(x => x.UserId == id).ToList();
    }
}
