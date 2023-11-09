using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.OrderDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.OrderManager
{
    public class OrderManager : IOrderManager
    {
        #region Inject
        private readonly IUnitOfWork _IUnitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _IUnitOfWork = unitOfWork;

        }

        public IUnitOfWork? UnitOfWork { get; }
        #endregion

        #region Add
        public bool Add(OrderAddDto Ordertobeadded)
        {
            Order? order = new Order();
            order.TotalPrice = Ordertobeadded.TotalPrice;
            order.Status = false;
            order.CreatedAt = DateTime.Now;
            order.ExpectedDelivaryDate = DateTime.Today.AddDays(5);
            order.AddressId = Ordertobeadded.AddressId;
            order.UserId = Ordertobeadded.UserId;
            order.ShippingCompanyId = Ordertobeadded.ShippingCompanyId;
            _IUnitOfWork.OrderRepo.Add(order);
            _IUnitOfWork.SaveChanges();
            return true;

        }
        #endregion

        #region Delete
        public bool Delete(int orderid)
        {
            Order? ordertobedeleted = _IUnitOfWork.OrderRepo.GetById(orderid);
            if(ordertobedeleted == null)
            {
                return false;
            }
            _IUnitOfWork.OrderRepo.Delete(ordertobedeleted);
            _IUnitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Update
        public bool Update(OrderUpdateDto ordertobeupdated)
        {
            Order? order = _IUnitOfWork.OrderRepo.GetById(ordertobeupdated.Id);
            if(order == null)
            {
                return false;
            }
            order.TotalPrice = ordertobeupdated.TotalPrice;
            order.Status = ordertobeupdated.Status;
            order.DeliveryDate = ordertobeupdated.DeliveryDate;
            order.ExpectedDelivaryDate = ordertobeupdated.ExpectedDelivaryDate;
            order.ShippingCompanyId = ordertobeupdated.ShippingCompanyId;
            order.AddressId = ordertobeupdated.AddressId;
            _IUnitOfWork.OrderRepo.Update(order);
            _IUnitOfWork.SaveChanges();
            return true;
    }
        #endregion

        #region Get Orders By Shipping Company
        public IEnumerable<ReadOrdersByShippingCompanyIdDto> GetOrdersByShippingCompanyId(int shippingcompanyId)
        {
            IEnumerable<Order>? ordersfromdb = _IUnitOfWork.OrderRepo.GetOrdersByShippingCompanyId(shippingcompanyId);
            if (ordersfromdb == null)
            {
                return Enumerable.Empty<ReadOrdersByShippingCompanyIdDto>();
            }
            return ordersfromdb.Select(o=>new ReadOrdersByShippingCompanyIdDto
                {
                    Id = o.Id,
                    TotalPrice = o.TotalPrice, 
                    Status = o.Status,
                    DeliveryDate = o.DeliveryDate,
                    CreatedAt = o.CreatedAt,
                    ExpectedDelivaryDate = o.ExpectedDelivaryDate,
                    UserAddress = o.UserAddress,
                    OrderItems = o.OrderItems,
                }
            );
        }
        #endregion

        #region Get Orders By User Id
        public IEnumerable<ReadOrdersByUserIdDto> GetOrdersByUserId(string userId)
        {
            IEnumerable<Order>? ordersfromdb = _IUnitOfWork.OrderRepo.GetOrderssByUserId(userId);
            if (ordersfromdb == null)
            {
                return Enumerable.Empty<ReadOrdersByUserIdDto>();
            }
            return ordersfromdb.Select(o => new ReadOrdersByUserIdDto
            {
                Id = o.Id,
                TotalPrice = o.TotalPrice,
                Status = o.Status,
                DeliveryDate = o.DeliveryDate,
                CreatedAt = o.CreatedAt,
                ExpectedDelivaryDate = o.ExpectedDelivaryDate,
                UserAddress = o.UserAddress,
                OrderItems = o.OrderItems,
            }
            );
        }
        #endregion

        #region Get Order By Id
        public ReadOrderByIdDto? GetOrderById(int orderid)
        {
            Order? orderfromdb = _IUnitOfWork.OrderRepo.GetById(orderid);
            if (orderfromdb == null)
            {
                return null;
            }
            ReadOrderByIdDto ordertoreturn = new ReadOrderByIdDto();

            ordertoreturn.TotalPrice = orderfromdb.TotalPrice;
            ordertoreturn.Status = orderfromdb.Status;
            ordertoreturn.DeliveryDate = orderfromdb.DeliveryDate;
            ordertoreturn.CreatedAt = orderfromdb.CreatedAt;
            ordertoreturn.ExpectedDelivaryDate = orderfromdb.ExpectedDelivaryDate;
            ordertoreturn.User = orderfromdb.User;
            ordertoreturn.ShippingCompany = orderfromdb.ShippingCompany;
            ordertoreturn.UserAddress = orderfromdb.UserAddress;
            ordertoreturn.OrderItems = orderfromdb.OrderItems;
            ordertoreturn.PaymentDetails = orderfromdb.PaymentDetails;
            return ordertoreturn;
    }
        #endregion
    }
}
