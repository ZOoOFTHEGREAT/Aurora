using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class ShippingCompanyRepo : GenericRepo<ShippingCompany>, IShippingCompanyRepo
{
    public ShippingCompanyRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
