﻿using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.ShippingCompanyDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.ShippingCompanyManager
{
    public class ShippingCompanyManager : IShippingCompanyManager
    {
        #region Inject Of UnitWork

        private readonly IUnitOfWork unitOfWork;

        public ShippingCompanyManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Add Shipping Comapny
        public int AddShippingCompany(AddShippingCompanyDto ShippingCompany)
        {
            ShippingCompany shippingCompany = new ShippingCompany()
            {
                Name = ShippingCompany.Name,
                ServicePrice = ShippingCompany.ServicePrice,
                WebSite = ShippingCompany.WebSite,
                Telephone = ShippingCompany.Telephone,
            };
            unitOfWork.ShippingCompanyRepo.Add(shippingCompany);
            return unitOfWork.SaveChanges();

        }
        #endregion

        #region Get All Shipping Company Names & IDs
        public IEnumerable<ReadShippingCompaniesDto> GetAllShippingCompany()
        {
            IEnumerable<ReadShippingCompaniesDto> shippingCompanies = unitOfWork.ShippingCompanyRepo.GetAll().Select(x=> new ReadShippingCompaniesDto
            {
                Id = x.Id,
                Name = x.Name,
                NumberOfOrders = x.Orders.Count,
            });
            return shippingCompanies;
        }

        #endregion

        #region Get All Shipping Company With Details
        public IEnumerable<ReadShippingCompaniesDetailsDto> GetAllShippingCompanyDetails()
        {
            IEnumerable<ReadShippingCompaniesDetailsDto> shippingCompaniesWithDetails = unitOfWork.ShippingCompanyRepo.GetAll().Select(x => new ReadShippingCompaniesDetailsDto
            {
                Name = x.Name,
                ServicePrice = x.ServicePrice,
                WebSite = x.WebSite,
                Telephone = x.Telephone,
            });
            return shippingCompaniesWithDetails;
        }


        #endregion

        #region Delete Shipping Company
        public bool IsDeleted(int ShippingCompanyId)
        {
            ShippingCompany? ShippingCompany = unitOfWork.ShippingCompanyRepo.GetById(ShippingCompanyId);
            if (ShippingCompany == null) { return false; }
            unitOfWork.ShippingCompanyRepo.Delete(ShippingCompany);
            return unitOfWork.SaveChanges() > 0;
        }

        #endregion

        #region Update

        public bool Update(UpdateShippinCompanyDto ShippingCompany)
        {
            ShippingCompany? shippingcompanytobeupdated = unitOfWork.ShippingCompanyRepo.GetById(ShippingCompany.Id);
            if (shippingcompanytobeupdated == null)
            {

                return false;
            }
            shippingcompanytobeupdated.ServicePrice = ShippingCompany.ServicePrice;
            shippingcompanytobeupdated.WebSite = ShippingCompany.WebSite;
            shippingcompanytobeupdated.Telephone = ShippingCompany.Telephone;

            unitOfWork.ShippingCompanyRepo.Update(shippingcompanytobeupdated);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

    }
}
