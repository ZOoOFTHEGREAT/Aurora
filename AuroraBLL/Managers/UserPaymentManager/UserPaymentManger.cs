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

        #region Add , GetAll , GetById , GetPaymentByUserId , Delete , Update
        public int Add(AddUserPaymentDto addUserPaymentDto)
        {
             if (addUserPaymentDto == null)
             {
                return 0;
             }

            var userPayment = new UserPayment
            {
                PaymentType = addUserPaymentDto.PaymentType,
                Provider = addUserPaymentDto.Provider,
                AccountNumber = addUserPaymentDto.AccountNumber,
            };

            unitOfWork.UserPaymentRepo.Add(userPayment);
            unitOfWork.SaveChanges();
            return userPayment.Id;
        }
        public List<ReadUserPaymentDto> GetAll()
        {
            var userPayments = unitOfWork.UserPaymentRepo.GetAll();
            if (userPayments == null)
            {
                return null!;
                //throw new ArgumentNullException(nameof(User),
                //    "UserPayments is Null");
            }

            return userPayments.Select(i => new ReadUserPaymentDto
            {
                 PaymentType=i.PaymentType,
                 Provider=i.Provider,
                 AccountNumber=i.AccountNumber,
                 ExpireDate=i.ExpireDate
            }).ToList();
        }
        public ReadUserPaymentDetailDto GetById(ReadUserPaymentDetailDto userPaymentDetailDto)
        {
            if (userPaymentDetailDto == null)
            {
                return null!;
                //throw new ArgumentNullException(nameof(userPaymentDetailDto), "UserPayment DTO is null in the parameter");
            }

            var userPayment = unitOfWork.UserPaymentRepo.GetById(userPaymentDetailDto.Id);
            if (userPayment == null)
            {
                return null!;
                //throw new ArgumentNullException(nameof(userPayment), "UserPayment is Not Exist");
            }

            return new ReadUserPaymentDetailDto
            {
                PaymentType = userPayment.PaymentType,
                AccountNumber = userPayment.AccountNumber,
                Provider = userPayment.Provider,
                ExpireDate = userPayment.ExpireDate,
                PaymentDetails = userPayment.PaymentDetails
                //Need Payment Details Dto
            };
        }
        public bool IsUpdated(UpdateUserPaymentDto updateUserPaymentDto)
        {
            if (updateUserPaymentDto == null)
            {
                return false;
            }

            var userPayment = unitOfWork.UserPaymentRepo.GetById(updateUserPaymentDto.Id);

            if (userPayment == null)
            {
                return false;
            }

            userPayment.AccountNumber = updateUserPaymentDto.AccountNumber;
            userPayment.PaymentType = updateUserPaymentDto.PaymentType;
            userPayment.Provider = updateUserPaymentDto.Provider;
            unitOfWork.SaveChanges();
            return true;
        }
        public ReadUserPaymentByUserIdDto GetUserPaymentByUserId(ReadUserPaymentByUserIdDto readUserPaymentByUserIdDto)
        {
            if (readUserPaymentByUserIdDto == null)
            {
                return null!;
                //throw new ArgumentNullException(nameof(readUserPaymentByUserIdDto), "UserPayment DTO is null in the parameter");
            }

            var userPayment = unitOfWork.UserPaymentRepo.GetUserPaymentByUserId(readUserPaymentByUserIdDto.UserId);
            if (userPayment == null)
            {
                return null!;
                //throw new ArgumentNullException(nameof(userPayment), "UserPayment is Not Exist");
            }

            return new ReadUserPaymentByUserIdDto
            {
                UserId = userPayment.UserId,
                PaymentType = userPayment.PaymentType,
                AccountNumber = userPayment.AccountNumber,
                Provider = userPayment.Provider,
                ExpireDate = userPayment.ExpireDate,
                PaymentDetailsDto = userPayment.PaymentDetails.Select(i =>
                new ReadAllPaymentDetailsDto
                {
                    Amount = i.Amount,
                    Status = i.Status,
                    Date = i.Date
                }).ToList()
            };
        }
        public bool IsDeleted(DeleteUserPaymentDto deleteUserPaymentDto)
        {
            if (deleteUserPaymentDto == null)
            {
                return false;
            }

            var userPayment = unitOfWork.UserPaymentRepo.GetById(deleteUserPaymentDto.Id);
            if (userPayment == null)
            {
                return false;
            }

            unitOfWork.UserPaymentRepo.Delete(userPayment);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion
    }
}
