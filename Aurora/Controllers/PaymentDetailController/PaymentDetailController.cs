using AuroraAPI.Services.Email;
using AuroraBLL.Dtos.CategoryDtos;
using AuroraBLL.Dtos.MailRequestDtos;
using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraBLL.Managers.CategoryManager;
using AuroraBLL.Managers.PaymentDetailManager;
using AuroraBLL.Managers.ShippingCompanyManager;
using AuroraDAL;
using AuroraDAL.Data.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        #region Inject 

        private readonly IPaymentDetailManager PaymentDetailManager;

        public PaymentDetailController(IPaymentDetailManager PaymentDetailManager)
        {
            this.PaymentDetailManager = PaymentDetailManager;
        }

        #endregion

        #region Get All Payment Details 
        [HttpGet]
        [Route("AllPayment")]
        public ActionResult<IEnumerable<ReadAllPaymentDetailsDto>> GetAllPaymentDetails()
        {
            IEnumerable<ReadAllPaymentDetailsDto> paymentDetails = PaymentDetailManager.GetAllPaymentDetails();
            return Ok(paymentDetails);
        }
        #endregion

        #region Get All Payment Details By Order ID
        [HttpGet]
        [Route("Byorder/{orderId}")]

        public ActionResult<IEnumerable<ReadPaymentDetailsByOrderIdDto>> GetAllPaymentDetailsByOrderId(int orderId)
        {
            IEnumerable<ReadPaymentDetailsByOrderIdDto>? PaymentDetails = PaymentDetailManager.GetPaymentDetailByOrderID(orderId);
            if (PaymentDetails == null) { return NotFound(); }
            return Ok(PaymentDetails);

        }
        #endregion

        #region Get All Payment Details By User Payment ID
        [HttpGet]
        [Route("ByuserPayment/{userPaymentId}")]

        public ActionResult<IEnumerable<ReadPaymentDetailsByUserPaymentDto>> GetAllPaymentDetailsByUserPaymentId(int userPaymentId)
        {
            IEnumerable<ReadPaymentDetailsByUserPaymentDto>? PaymentDetails = PaymentDetailManager.GetPaymentDetailByUserPaymentId(userPaymentId);
            if (PaymentDetails == null) { return NotFound(); }
            return Ok(PaymentDetails);

        }
        #endregion

        #region Add PaymentDetail
        [HttpPost]
        [Route("AddPayment")]

        public ActionResult Add(AddPaymentDetailDto paymentDetail)
        {   
            int isAdded = PaymentDetailManager.Add(paymentDetail);
            return isAdded>0? Ok(isAdded) : BadRequest(isAdded);
        }
        #endregion

    }
}
