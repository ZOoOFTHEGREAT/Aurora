using AuroraBLL.Dtos.ImageDtos;
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
using static System.Net.Mime.MediaTypeNames;

namespace AuroraBLL.Managers.UserAddressManager
{
    public class UserAddressManager : IUserAddressManager
    {
        #region Inject IUnit Of Work

        private readonly IUnitOfWork unitOfWork;

        public UserAddressManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        #endregion

        #region Add 
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
                City = addUserAddressDto.City,
                UserId = addUserAddressDto.UserId,
            };
            unitOfWork.UserAddressRepo.Add(userAddress);
            unitOfWork.SaveChanges();
            return userAddress.Id;
        }
        #endregion

        #region Delete
        public bool IsDeleted(int addressId)
        {
            UserAddress? AddressToBeDeleted = unitOfWork.UserAddressRepo.GetById(addressId);
            if (AddressToBeDeleted == null)
            {
                return false;
            }
            unitOfWork.UserAddressRepo.Delete(AddressToBeDeleted);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Update
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
        #endregion

        #region Get By Id
        public ReadUserAddressDetailDto GetById(int id)
        {
            if (id == 0)
                return null!;

            var userAddress = unitOfWork.UserAddressRepo.GetById(id);
            if (userAddress == null)
                return null!;

            return new ReadUserAddressDetailDto
            {
                Address = userAddress.Address,
                LineOne = userAddress.LineOne,
                LineTwo = userAddress.LineTwo,
                Country = userAddress.Country,
                City = userAddress.City,
                UserId = userAddress.UserId,
            };
        }
        #endregion

        #region Get By User Id
        public IEnumerable<ReadUserAddresByUserIdDto> GetAddressByUserId(string userId)
        {
            IEnumerable<UserAddress>? Addressesfromdb = unitOfWork.UserAddressRepo.GetAddressesByUserId(userId);
            if (Addressesfromdb == null)
            {
                return Enumerable.Empty<ReadUserAddresByUserIdDto>();
            }
            return Addressesfromdb.Select(I => new ReadUserAddresByUserIdDto
            {
                Address = I.Address,
                LineOne = I.LineOne,
                LineTwo = I.LineTwo,
                Country = I.Country,
                City = I.City
            });
        }
        #endregion
    }
}
