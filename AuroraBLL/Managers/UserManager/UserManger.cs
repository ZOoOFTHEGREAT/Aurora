using AuroraBLL.Dtos.OrderDtos;
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

        #region Add GetAllUser GetAllUsers GetUserById GetUserDetailsById UpdateUser IsDeleted
        public int Add(AddUserDto user)
        {
            User usr = new()
            {
                UserName = user.UserName,
                Email=user.Email,
                Fname=user.Fname,
                Lname=user.Lname,
                PhoneNumber=user.PhoneNumber,
                ZipCode=user.ZipCode,
                PasswordHash=user.PasswordHash
            };
            unitOfWork.UserRepo.Add(usr);
            return unitOfWork.SaveChanges();
        }
        
        public List<ReadAllUserDto> GetAllUsers()
        {
            var user = unitOfWork.UserRepo.GetAll();

            if (user == null)
            {
                return null!;
            }

            return  user.Select(i => new ReadAllUserDto
            {
                Id=i.Id,
                UserName =i.UserName!,
                PhoneNumber = i.PhoneNumber!,
                Email=i.Email!,
                PasswordHash=i.PasswordHash!,
                ZipCode=i.ZipCode,
                Fname=i.Fname,
                Lname=i.Lname
            }).ToList();
        }

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
                OrderDtos = userDetails.Orders.Select(i => new ReadOrderDto
                {
                    TotalPrice = i.TotalPrice,
                    Status = i.Status,
                    DeliveryDate = i.DeliveryDate,
                    CreatedAt = i.CreatedAt,
                    ExpectedDelivaryDate = i.ExpectedDelivaryDate
                }).ToList(),
                UserAddressesDtos = userDetails.UserAddresses.Select(i => new ReadUserAddressDto
                {
                    Address = i.Address,
                    LineOne = i.LineOne,
                    LineTwo = i.LineTwo,
                    Country = i.Country,
                    City = i.City,
                }).ToList(),
                UserPaymentDtos = userDetails.UserPayments.
                Select(i => new ReadUserPaymentDto
                {
                    PaymentType = i.PaymentType,
                    Provider = i.Provider,
                    AccountNumber = i.AccountNumber,
                    ExpireDate = i.ExpireDate,
                }).ToList()
            };
        }

        public bool IsUpdated(UpdateUserDto userDto)
        {
            if (userDto == null || userDto.Id=="")
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

        public bool IsDeleted(DeleteUserDto userDto)
        {
            if (userDto == null || userDto.Id == "")
                return false;
            var getUser = unitOfWork.UserRepo.GetUserById(userDto.Id);
            if (getUser == null)
                return false;

            unitOfWork.UserRepo.Delete(getUser);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion
    }
}
