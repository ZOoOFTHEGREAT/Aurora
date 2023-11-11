using AuroraBLL.Dtos;
using AuroraBLL.Dtos.CartDtos;
using AuroraBLL.Dtos.CartItemDtos;
using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.OrderItemDtos;
using AuroraBLL.Dtos.ShippingCompanyDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.OrderItemManager
{
    public class OrderItemManager : IOrderItemManager
    {
        #region Inject
        private readonly IUnitOfWork unitOfWork;
        public OrderItemManager(IUnitOfWork unitOfWork)
        {

            this.unitOfWork = unitOfWork;

        }
        #endregion

        #region Add Order Item
        public int AddOrderItem(AddOrderItemDto addOrderItem)
        {
            OrderItem OrderItemRequested = new OrderItem()
            {
                OrderId = addOrderItem.OrderId,
                Quantity = addOrderItem.Quantity,
                ProductId = addOrderItem.ProductId,
  
            };
            unitOfWork.OrderItemRepo.Add(OrderItemRequested);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Delete Order Item
        public bool DeleteOrderItem(int id)
        {
            OrderItem? OrderItemDelete = unitOfWork.OrderItemRepo.GetById(id);
            if (OrderItemDelete == null) { return false; }
            unitOfWork.OrderItemRepo.Delete(OrderItemDelete);
             unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Read order Items By Order Id 
        public IEnumerable<ReadOrderItemsByOrderIdDto>? GetOrderItemsByOrderId(int orderid)
        {
            IEnumerable<OrderItem>? orderItems = unitOfWork.OrderItemRepo.GetOrderItemByOrderId(orderid);
            if (orderItems == null)
            {
                return Enumerable.Empty<ReadOrderItemsByOrderIdDto>();
            }
            return orderItems.Select(OT => new ReadOrderItemsByOrderIdDto
            {
                Quantity = OT.Quantity,
                ProductId = OT.ProductId,
            });
         }
        #endregion

        #region Update Order Item
        public bool UpdateOrderItem(UpdateOrderItemDto updateOrderItemDto)
        {
            OrderItem? orderItemUpdate = unitOfWork.OrderItemRepo.GetById(updateOrderItemDto.Id);
            if (orderItemUpdate == null) { return false; }

           orderItemUpdate.Quantity = updateOrderItemDto.Quantity;
            unitOfWork.OrderItemRepo.Update(orderItemUpdate);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion
    }
}
