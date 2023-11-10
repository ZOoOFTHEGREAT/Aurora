using AuroraBLL.Dtos.OrderDtos;
using AuroraBLL.Dtos.UserAddressDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.UserAddressManager
{
    public class UserAddressManager: IUserAddressManager
    {
        #region Inject IUnit Of Work

        private readonly IUnitOfWork unitOfWork;

        public UserAddressManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        #endregion

        #region Add , GetAll , GetById , Delete , Update , GetAddressByUserId
        public int Add(AddUserAddressDto addUserAddressDto)
        {
            if (addUserAddressDto == null)
                return 0;
            var userAddress = new UserAddress()
            {
                Address = addUserAddressDto.Address,
                LineOne = addUserAddressDto.LineOne,
                LineTwo = addUserAddressDto.LineTwo,
                Country = addUserAddressDto.Country,
                City = addUserAddressDto.City
            };
            unitOfWork.UserAddressRepo.Add(userAddress);
            unitOfWork.SaveChanges();
            return userAddress.Id;         
        }
        public ReadUserAddresByUserIdDto GetAddressByUserId(string userId)
        {
            if (userId == "")
                return null!;
            var userAddress = unitOfWork.UserAddressRepo.GetUserAddresByUserId(userId);
            if (userAddress == null)
                return null!;
            return new ReadUserAddresByUserIdDto
            {
                Address = userAddress.Address,
                LineOne = userAddress.LineOne,
                LineTwo = userAddress.LineTwo,
                Country = userAddress.Country,
                City = userAddress.City
            };
        }
        public List<ReadUserAddressDto> GetAll()
        {
            var userAddresses =unitOfWork.UserAddressRepo.GetAll();
            if (userAddresses == null)
                return null!;
            return userAddresses.Select(i => new ReadUserAddressDto
            {
                Address = i.Address,
                LineOne = i.LineOne,
                LineTwo = i.LineTwo,
                Country = i.Country,
                City = i.City
            }).ToList();            
        }
        public ReadUserAddressDetailDto GetById(ReadUserAddressDetailDto readUserAddressDetailDto)
        {
            if (readUserAddressDetailDto == null)
                return null!;

            var userAddress = unitOfWork.UserAddressRepo.GetById(readUserAddressDetailDto.Id);
            if (userAddress == null)
                return null!;

            return new ReadUserAddressDetailDto
            {
                Address = userAddress.Address,
                LineOne = userAddress.LineOne,
                LineTwo = userAddress.LineTwo,
                Country = userAddress.Country,
                City = userAddress.City,
                OrdersDto = userAddress.Orders.Select(i => new ReadOrderDto
                {
                    CreatedAt = i.CreatedAt,
                    TotalPrice = i.TotalPrice,
                    Status = i.Status,
                    DeliveryDate = i.DeliveryDate
                }).ToList()
            };
        }
        public bool IsUpdated(UpdateUserAddressDto updateUserAddressDto)
        {
            if (updateUserAddressDto == null)
                return false;
            var userAddress = unitOfWork.UserAddressRepo.GetById(updateUserAddressDto.Id);
            if (userAddress == null)
                return false;
            userAddress.Address = updateUserAddressDto.Address;
            userAddress.LineOne = updateUserAddressDto.LineOne;
            userAddress.LineTwo = updateUserAddressDto.LineTwo;
            userAddress.Country = updateUserAddressDto.Country;
            userAddress.City = updateUserAddressDto.City;

            unitOfWork.UserAddressRepo.Add(userAddress);
            unitOfWork.SaveChanges();
            return true;
        }
        public bool IsDeleted(DeleteUserAddressDto deleteUserAddressDto)
        {
            if (deleteUserAddressDto == null)
                return false;
            var userAddress = unitOfWork.UserAddressRepo.GetById(deleteUserAddressDto.Id);
            if (userAddress == null)
                return false;
            unitOfWork.UserAddressRepo.Delete(userAddress);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

    }
}
