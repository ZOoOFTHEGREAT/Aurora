using AuroraBLL.Dtos;
using AuroraBLL.Dtos.CartDtos;
using AuroraBLL.Dtos.CartItemDtos;
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
                Id = addOrderItem.Id,
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

        #region Read order Item 
        public IEnumerable<ReadOrderItemDto>? GetOrderItemsByOrderId(int orderid)
        {
            IEnumerable<ReadOrderItemDto> OrderItems = unitOfWork.OrderItemRepo.GetOrderItemByOrderId(orderid).Select(x => new ReadOrderItemDto
            {
                Quantity = x.Quantity,
                ProductId = x.ProductId,
                Product = new Product() { Name = x.Product.Name },

            }).ToList();
            return OrderItems;


        }
        #endregion

        #region Read Order Details
        public ReadOrderItemDetailDto? GetOrderItemDetailDto(int id)
        {
            OrderItem? OrderItem = unitOfWork.OrderItemRepo.GetById(id);
            if (OrderItem == null)
            {
                return null;
            }
            return new ReadOrderItemDetailDto
            {
               Id = OrderItem.Id, ProductId = OrderItem.ProductId,
               Quantity = OrderItem.Quantity,
               OrderId = OrderItem.OrderId,
               //Check
               Product = new Product() { Name = OrderItem.Product.Name },

            };
        }
        #endregion

        #region Update Order Item
        public bool UpdateOrderItem(UpdateOrderItemDto updateOrderItemDto)
        {
            OrderItem? orderItemUpdate = unitOfWork.OrderItemRepo.GetById(updateOrderItemDto.Id);
            if (orderItemUpdate == null) { return false; }

           orderItemUpdate.Quantity = updateOrderItemDto.Quantity;
            orderItemUpdate.ProductId = updateOrderItemDto.ProductId;
            unitOfWork.OrderItemRepo.Update(orderItemUpdate);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion
    }
}
