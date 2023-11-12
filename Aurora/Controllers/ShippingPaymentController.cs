using AuroraBLL.Dtos.CategoryDtos;
using AuroraBLL.Dtos.ShippingCompanyDtos;
using AuroraBLL.Managers.CategoryManager;
using AuroraBLL.Managers.ShippingCompanyManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingPaymentController : ControllerBase
    {
        #region Inject 

        private readonly IShippingCompanyManager shippingCompanyManger;

        public ShippingPaymentController(IShippingCompanyManager shippingCompanyManger)
        {
            this.shippingCompanyManger = shippingCompanyManger;
        }

        #endregion

        #region Get All Shipping Companies
        [HttpGet]
        [Route("ShippingCompany")]

        public ActionResult<IEnumerable<ReadShippingCompaniesDto>> GetAllShippingCompanies()
        {
            IEnumerable<ReadShippingCompaniesDto> shippingCompanies = shippingCompanyManger.GetAllShippingCompany();
            if (shippingCompanies == null) { return NotFound(); }
            return Ok(shippingCompanies);
        }

        #endregion

        #region Get All Shipping Companies with Details
        [HttpGet]
        [Route("ShippingCompanyDetails")]

        public ActionResult<IEnumerable<ReadShippingCompaniesDetailsDto>> GetAllShippingCompaniesWithDetails()
        {
            IEnumerable<ReadShippingCompaniesDetailsDto> shippingCompaniesWithDetails = shippingCompanyManger.GetAllShippingCompanyDetails();
            if (shippingCompaniesWithDetails == null) { return NotFound(); }
            return Ok(shippingCompaniesWithDetails);
        }
        #endregion

        #region Add Shipping Company
        [HttpPost]
        [Route("AddShippingCompany")]

        public ActionResult Add(AddShippingCompanyDto shippingCompany)
        {
            int isAdded = shippingCompanyManger.AddShippingCompany(shippingCompany);
            return isAdded>0 ? Ok(isAdded) : BadRequest(isAdded);    
        }
        #endregion

        #region Update Shipping Company
        [HttpPut]
        [Route("UpdateShippingCompany")]

        public ActionResult Edit(UpdateShippinCompanyDto ShippingToUpdate)
        {
            bool isEdited = shippingCompanyManger.Update(ShippingToUpdate);
            return isEdited ? Accepted() : BadRequest();
        }
        #endregion

        #region Delete Shipping Company By Id 
        [HttpDelete]
        [Route("{ShippingCompanyToDeleteId}")]

        public ActionResult Delete(int ShippingCompanyToDeleteId)
        {
            bool isDeleted = shippingCompanyManger.IsDeleted(ShippingCompanyToDeleteId);
            return isDeleted ? Accepted() : BadRequest();
        }
        #endregion
    }
}
