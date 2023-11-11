using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.PaymentDetailManager
{
    public class PaymentDetailManager : IPaymentDetailManager
    {
        #region Inject Of UnitWork

        private readonly IUnitOfWork unitOfWork;

        public PaymentDetailManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Get All Payment Details
        public IEnumerable<ReadAllPaymentDetailsDto> GetAllPaymentDetails()
        {
            IEnumerable<PaymentDetail> paymentDetails = unitOfWork.PaymentDetailRepo.GetAll();
            return paymentDetails.Select(x=> new ReadAllPaymentDetailsDto
            {
                Id = x.Id,
                Amount = x.Amount,
                Status = x.Status,
                Date = x.Date,
                UserPaymentId = x.UserPaymentId,
                OrderId = x.OrderId,
            });
        }
        #endregion

        #region Get PaymentDetails By Order Id

        public IEnumerable<ReadPaymentDetailsByOrderIdDto>? GetPaymentDetailByOrderID(int OrderId)
        {
            IEnumerable<PaymentDetail>? Payment = unitOfWork.PaymentDetailRepo.GetPaymentDetailsByOrderId(OrderId);
            if (Payment == null) { return null; }
            return Payment.Select(x=> new ReadPaymentDetailsByOrderIdDto
            {
                Id = x.Id,
                Amount = x.Amount,
                Status = x.Status,
                Date = x.Date,
                UserPaymentId = x.UserPaymentId,
            });

        }

        #endregion

        #region Get PaymentDetails By User Payment Id
        public IEnumerable<ReadPaymentDetailsByUserPaymentDto>? GetPaymentDetailByUserPaymentId(int UserPaymentId)
        {
            IEnumerable<PaymentDetail>? Payment = unitOfWork.PaymentDetailRepo.GetPaymentDetailsByUserPayment(UserPaymentId);
            if (Payment == null) { return null; }
            return Payment.Select(x=>new ReadPaymentDetailsByUserPaymentDto
            {
                Id = x.Id,
                Amount = x.Amount,
                Status = x.Status,
                Date = x.Date,
                OrderId = x.OrderId,
            });
        }
        #endregion

        #region Add
        int IPaymentDetailManager.Add(AddPaymentDetailDto paymentdetail)
        {

            PaymentDetail? newpayment = new PaymentDetail
            {
                Amount = paymentdetail.Amount,
                Status = paymentdetail.Status,
                OrderId = paymentdetail.OrderId,
                UserPaymentId = paymentdetail.UserPaymentId,
                Date = DateTime.Now,
            };

            unitOfWork.PaymentDetailRepo.Add(newpayment);
            return unitOfWork.SaveChanges();
        }
        #endregion
    }
}
