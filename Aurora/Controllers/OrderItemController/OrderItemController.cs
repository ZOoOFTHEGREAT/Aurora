using AuroraBLL.Dtos.OrderItemDtos;
using AuroraBLL.Managers.OrderItemManager;
using AuroraDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace AuroraAPI.Controllers.OrderItemController
{
    [Route("api/[controller]")]
    [ApiController]
    #region Inject
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemManager _orderItemManager;

        public OrderItemController(IOrderItemManager orderItemManager) {
            _orderItemManager = orderItemManager;
        }
        #endregion

    #region GetBy Id
        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<ReadOrderItemsByOrderIdDto>>? GetById(int orderid){
            IEnumerable<ReadOrderItemsByOrderIdDto>? orderItem = _orderItemManager.GetOrderItemsByOrderId(orderid);
           
            if (orderItem is null) {
                return NotFound();
            }
            return Ok(orderItem);
        
        }
        #endregion

    #region Add Order item
        [HttpPost]
        public ActionResult Add(AddOrderItemDto addOrderItemDto) {
            if (addOrderItemDto is null) {
            return NotFound(addOrderItemDto);
            }
           
           var orderItem =  _orderItemManager.AddOrderItem(addOrderItemDto);
            return CreatedAtAction(nameof(Add), orderItem);
             
        
        }
        #endregion

    #region Update order Item
        [HttpPut]
        public ActionResult Update(UpdateOrderItemDto UpdateDto) { 
        
        var isFound = _orderItemManager.UpdateOrderItem(UpdateDto);
            if (!isFound) {
                return NotFound();
            }
            return Ok(NoContent());
        
        
        }
        #endregion

    #region Delete order item
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {

           var isFound =  _orderItemManager.DeleteOrderItem(id);
            if (!isFound)
            {
                return NotFound();  
            }
            return Ok(NoContent());
        }
        #endregion
    }
}
