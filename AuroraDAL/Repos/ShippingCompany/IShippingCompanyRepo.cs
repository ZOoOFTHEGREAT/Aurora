using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IShippingCompanyRepo:IGenericRepo<ShippingCompany>
{
    new List<ShippingCompany> GetAll();
    new ShippingCompany? GetById(int id);
}
