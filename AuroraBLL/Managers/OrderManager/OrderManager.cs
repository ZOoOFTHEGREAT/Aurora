using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.OrderDtos;
using AuroraBLL.Dtos.OrderItemDtos;
using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraBLL.Dtos.UserPaymentDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            order.ExpectedDeliveryDate = DateTime.Today.AddDays(5);
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
            order.ExpectedDeliveryDate = ordertobeupdated.ExpectedDeliveryDate;
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
                    ExpectedDeliveryDate = o.ExpectedDeliveryDate,
                    AddressId = o.AddressId,
                    OrderItems = o.OrderItems.Select(orderitem => new ReadOrderItemDto
                    {
                        Quantity = orderitem.Quantity,
                        OrderId = orderitem.OrderId,
                        ProductId = orderitem.ProductId,
                    }).ToList(),
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
                ExpectedDeliveryDate = o.ExpectedDeliveryDate,
                AddressId = o.AddressId,
                ShippingCompanyId = o.ShippingCompanyId,
                OrderItems = o.OrderItems.Select(orderitem => new ReadOrderItemDto
                {
                    Quantity = orderitem.Quantity,
                    OrderId = orderitem.OrderId,
                    ProductId = orderitem.ProductId,
                }).ToList(),
                PaymentDetails = o.PaymentDetails.Select(PaymentDetail => new ReadPaymentDetailsDto
                {
                    Amount = PaymentDetail.Amount,
                    Status = PaymentDetail.Status,
                    Date = PaymentDetail.Date,
                    OrderId = PaymentDetail.OrderId,
                    UserPaymentId = PaymentDetail.UserPaymentId,
                }).ToList(),
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
            ordertoreturn.ExpectedDeliveryDate = orderfromdb.ExpectedDeliveryDate;
            ordertoreturn.UserId = orderfromdb.UserId;
            ordertoreturn.ShippingCompanyId = orderfromdb.ShippingCompanyId;
            ordertoreturn.AddressId = orderfromdb.AddressId;
            ordertoreturn.OrderItems = orderfromdb.OrderItems.Select(orderitem => new ReadOrderItemDto
            {
                Quantity = orderitem.Quantity,
                OrderId = orderitem.OrderId,
                ProductId = orderitem.ProductId,
            }).ToList();
            ordertoreturn.PaymentDetails = orderfromdb.PaymentDetails.Select(payment => new ReadPaymentDetailsDto
            {
               Amount = payment.Amount,
               Status = payment.Status,
               Date = payment.Date,
               OrderId = payment.OrderId,
               UserPaymentId = payment.UserPaymentId,
            }).ToList();
            return ordertoreturn;
    }
        #endregion
    }
}
