using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class OrderRepo : GenericRepo<Order>, IOrderRepo
{
    public OrderRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
