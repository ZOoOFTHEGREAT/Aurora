using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class ShippingCompanyRepo : GenericRepo<ShippingCompany>, IShippingCompanyRepo
{
    #region Inject 
    private readonly AppDbContext appDbContext;

    public ShippingCompanyRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;

    }
    #endregion

    public new List<ShippingCompany> GetAll()
    {
        return appDbContext.Set<ShippingCompany>().
           Include(ShippingCompany => ShippingCompany.Orders).
           ToList();
    }
    public new ShippingCompany? GetById(int id)
    {
        return appDbContext.Set<ShippingCompany>().
           Include(ShippingCompany => ShippingCompany.Orders).
           ThenInclude(Order => Order.Status).
           FirstOrDefault(ShippingCompany => ShippingCompany.Id == id);
    }
}
