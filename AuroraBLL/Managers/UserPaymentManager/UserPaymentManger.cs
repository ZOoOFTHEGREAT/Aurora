using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraBLL.Dtos.UserPaymentDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.UserPaymentManager
{
    public class UserPaymentManger : IUserPaymentManager
    {
        #region Inject IUnit Of Work
        private readonly IUnitOfWork unitOfWork;

        public UserPaymentManger(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Add 
        public int Add(AddUserPaymentDto addUserPaymentDto)
        {
            var userPayment = new UserPayment
            {
                PaymentType = addUserPaymentDto.PaymentType,
                Provider = addUserPaymentDto.Provider,
                AccountNumber = addUserPaymentDto.AccountNumber,
                ExpireDate = addUserPaymentDto.ExpireDate,
                UserId = addUserPaymentDto.UserId,
            };

            unitOfWork.UserPaymentRepo.Add(userPayment);
            unitOfWork.SaveChanges();
            return userPayment.Id;
        }
        #endregion

        #region Delete
        public bool IsDeleted(int userPaymentId)
        {
            var userPayment = unitOfWork.UserPaymentRepo.GetById(userPaymentId);
            if (userPayment == null)
            {
                return false;
            }

            unitOfWork.UserPaymentRepo.Delete(userPayment);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Get By Id
        public ReadUserPaymentDetailDto GetById(ReadUserPaymentDetailDto userPaymentDetailDto)
        {
            if (userPaymentDetailDto == null)
            {
                return null!;
            }

            var userPayment = unitOfWork.UserPaymentRepo.GetById(userPaymentDetailDto.Id);
            if (userPayment == null)
            {
                return null!;
            }

            return new ReadUserPaymentDetailDto
            {
                PaymentType = userPayment.PaymentType,
                AccountNumber = userPayment.AccountNumber,
                Provider = userPayment.Provider,
                ExpireDate = userPayment.ExpireDate,
                UserId = userPayment.UserId,
                PaymentDetails = userPayment.PaymentDetails.Select(payment => new ReadPaymentDetailsDto
                {
                    Amount = payment.Amount,
                    Status = payment.Status,
                    Date = payment.Date,
                    OrderId = payment.OrderId,
                    UserPaymentId = payment.UserPaymentId,
                }).ToList(),
            };
        }
        #endregion

        #region Get User Payment By User Id
        public ReadUserPaymentByUserIdDto GetUserPaymentByUserId(ReadUserPaymentByUserIdDto readUserPaymentByUserIdDto)
        {
            if (readUserPaymentByUserIdDto == null)
            {
                return null!;
            }

            var userPayment = unitOfWork.UserPaymentRepo.GetUserPaymentByUserId(readUserPaymentByUserIdDto.UserId);
            if (userPayment == null)
            {
                return null!;
            }

            return new ReadUserPaymentByUserIdDto
            {
                Id = userPayment.Id,
                PaymentType = userPayment.PaymentType,
                AccountNumber = userPayment.AccountNumber,
                Provider = userPayment.Provider,
                ExpireDate = userPayment.ExpireDate,
            };
        }
        #endregion
    }
}
