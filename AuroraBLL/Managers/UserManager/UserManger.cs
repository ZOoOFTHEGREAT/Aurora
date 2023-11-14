using AuroraBLL.Dtos.OrderDtos;
using AuroraBLL.Dtos.OrderItemDtos;
using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraBLL.Dtos.UserAddressDtos;
using AuroraBLL.Dtos.UserDtos;
using AuroraBLL.Dtos.UserPaymentDtos;
using AuroraDAL;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AuroraBLL.Managers.UserManager
{
    public class UserManger: IUserManger
    {
        #region Inject IUnit Of Work

        private readonly IUnitOfWork unitOfWork;

        public UserManger(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Add 
        public int Add(AddUserDto user)
        {
            User usr = new()
            {
                UserName = user.UserName,
                Email = user.Email,
                Fname = user.Fname,
                Lname = user.Lname,
                PhoneNumber = user.PhoneNumber,
                ZipCode = user.ZipCode,
                PasswordHash = user.PasswordHash
            };
            unitOfWork.UserRepo.Add(usr);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Update
        public bool IsUpdated(UpdateUserDto userDto)
        {
            if (userDto == null || userDto.Id == "")
                return false;

            var getUser = unitOfWork.UserRepo.GetUserById(userDto.Id);
            if (getUser == null)
                return false;

            getUser.UserName = userDto.UserName;
            getUser.Email = userDto.Email;
            getUser.Fname = userDto.Fname;
            getUser.Lname = userDto.Lname;
            getUser.PhoneNumber = userDto.PhoneNumber;
            getUser.PasswordHash = userDto.PasswordHash;
            getUser.ZipCode = userDto.ZipCode;
            unitOfWork.UserRepo.Update(getUser);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Delete
        public bool IsDeleted(string userid)
        {
            var getUser = unitOfWork.UserRepo.GetUserById(userid);
            if (getUser == null)
                return false;

            unitOfWork.UserRepo.Delete(getUser);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Get User By Id
        public ReadUserByIdDto GetUserById(string id)
        {
            if (id == "")
                return null!;

            var userById = unitOfWork.UserRepo.GetUserById(id);

            if (userById == null)
                return null!;

            return new ReadUserByIdDto()
            {
                UserName = userById!.UserName!,
                Fname = userById.Fname,
                Lname = userById.Lname,
                Email = userById.Email!,
                PasswordHash = userById.PasswordHash!,
                PhoneNumber = userById.PhoneNumber!,
                ZipCode = userById.ZipCode,
            };
        }
        #endregion

        #region Get User Details By Id
        public ReadUserDetailsByIdDto GetUserDetailsById(string id)
        {
            if (id == "")
                return null!;
            var userDetails = unitOfWork.UserRepo.GetUserById(id);
            if (userDetails == null)
                return null!;

            return new ReadUserDetailsByIdDto
            {
                UserName = userDetails.UserName!,
                Fname = userDetails.Fname!,
                Lname = userDetails.Lname,
                Email = userDetails.Email!,
                PasswordHash = userDetails.PasswordHash!,
                PhoneNumber = userDetails.PhoneNumber!,
                ZipCode = userDetails.ZipCode,
                Orders = userDetails.Orders.Select(i => new ReadOrdersDto
                {
                    TotalPrice = i.TotalPrice,
                    Status = i.Status,
                    DeliveryDate = i.DeliveryDate,
                    CreatedAt = i.CreatedAt,
                    ExpectedDeliveryDate = i.ExpectedDeliveryDate,
                    ShippingCompanyId = i.ShippingCompanyId,
                    AddressId = i.AddressId,
                    OrderItems = i.OrderItems.Select(orderitem => new ReadOrderItemDto
                    {
                        Quantity = orderitem.Quantity,
                        OrderId = orderitem.OrderId,
                        ProductId = orderitem.ProductId,
                    }).ToList(),
                    PaymentDetails = i.PaymentDetails.Select(payment => new ReadPaymentDetailsDto
                    {
                        Amount = payment.Amount,
                        Status = payment.Status,
                        Date = payment.Date,
                        OrderId = payment.OrderId,
                        UserPaymentId = payment.UserPaymentId,
                    }).ToList()
                }).ToList(),
                UserAddresses = userDetails.UserAddresses.Select(i => new ReadUserAddressDetailDto
                {
                    Address = i.Address,
                    LineOne = i.LineOne,
                    LineTwo = i.LineTwo,
                    Country = i.Country,
                    City = i.City,
                }).ToList(),
                UserPayments = userDetails.UserPayments.Select(i => new ReadUserPaymentDetailDto
                {
                    PaymentType = i.PaymentType,
                    Provider = i.Provider,
                    AccountNumber = i.AccountNumber,
                    ExpireDate = i.ExpireDate,
                }).ToList()
            };
        }
        #endregion

        #region Get User By Phone Number
        public ReadUserByPhoneNumberDto GetUserByPhoneNumber(string phoneNumber)
        {
            var userByphonenumber = unitOfWork.UserRepo.GetUSerByPhoneNumber(phoneNumber);

            if (userByphonenumber == null)
                return null!;

            return new ReadUserByPhoneNumberDto()
            {
                Id = userByphonenumber.Id,
                UserName = userByphonenumber!.UserName!,
                Fname = userByphonenumber.Fname,
                Lname = userByphonenumber.Lname,
                Email = userByphonenumber.Email!,
                PasswordHash = userByphonenumber.PasswordHash!,
                PhoneNumber = userByphonenumber.PhoneNumber!,
                ZipCode = userByphonenumber.ZipCode,
            };
        }
        #endregion

        #region Get User By Email
        public ReadUserByEmailDto GetUserByEmail(string email)
        {
            var userByemail = unitOfWork.UserRepo.GetUSerByEmail(email);

            if (userByemail == null)
                return null!;

            return new ReadUserByEmailDto()
            {
                Id = userByemail.Id,
                UserName = userByemail!.UserName!,
                Fname = userByemail.Fname,
                Lname = userByemail.Lname,
                Email = userByemail.Email!,
                PasswordHash = userByemail.PasswordHash!,
                PhoneNumber = userByemail.PhoneNumber!,
                ZipCode = userByemail.ZipCode,
            };
        }
        #endregion
    }
}
