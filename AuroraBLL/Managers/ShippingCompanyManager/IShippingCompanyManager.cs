using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.ShippingCompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.ShippingCompanyManager
{
    public interface IShippingCompanyManager
    {
        int AddShippingCompany(AddShippingCompanyDto ShippingCompany);
        bool IsDeleted(int ShippingCompanyId);
        bool Update(UpdateShippinCompanyDto ShippingCompany);

        IEnumerable<ReadShippingCompaniesDto> GetAllShippingCompany();
        IEnumerable<ReadShippingCompaniesDetailsDto> GetAllShippingCompanyDetails();

    }
}
