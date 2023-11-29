using AuroraBLL.Dtos.OrderDtos;
using AuroraBLL.Dtos.ProductDtos;
using AuroraBLL.Managers.OrderManager;
using AuroraBLL.Managers.ProductManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers.OrderController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Inject
        private readonly IOrderManager ordermanager;

        public OrderController(IOrderManager ordermanager)
        {
            this.ordermanager = ordermanager;
        }
        #endregion

        #region Add
        [HttpPost]
        [Route("AddOrder")]

        public ActionResult Add(OrderAddDto OrderToAdd)
        {
            bool isAdded = ordermanager.Add(OrderToAdd);
            return isAdded ? Accepted() : BadRequest();
        }
        #endregion

        #region Update
        [HttpPut]
        [Route("UpdateOrder")]

        public ActionResult Edit(OrderUpdateDto orderToUpdate)
        {
            bool isEdited = ordermanager.Update(orderToUpdate);

            return isEdited ? Accepted() : BadRequest();
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{OrderToDeleteId}")]

        public ActionResult Delete(int orderToDeleteId)
        {
            bool isDeleted = ordermanager.Delete(orderToDeleteId);

            return isDeleted ? Accepted() : BadRequest();
        }
        #endregion

        #region Get Orders By Shipping Company
        [HttpGet]
        [Route("Byshippingcompany/{shippingcompanyId}")]

        public ActionResult<IEnumerable<ReadOrdersByShippingCompanyIdDto>> GetAllOrdersByShippingCompanyId(int shippingcompanyId)
        {
            IEnumerable<ReadOrdersByShippingCompanyIdDto>? orders = ordermanager.GetOrdersByShippingCompanyId(shippingcompanyId);
            if (orders == null) { return NotFound(); }
            return Ok(orders);

        }
        #endregion

        #region Get Orders By User Id
        [HttpGet]
        [Route("Byuser/{UserId}")]

        public ActionResult<IEnumerable<ReadOrdersByUserIdDto>> GetAllOrdersByUserId(string UserId)
        {
            IEnumerable<ReadOrdersByUserIdDto>? orders = ordermanager.GetOrdersByUserId(UserId
                );
            if (orders == null) { return NotFound(); }
            return Ok(orders);

        }
        #endregion

        #region Get Order By Id
        [HttpGet]
        [Route("{OrderId}")]
        public ActionResult<ReadOrderByIdDto> GetOrder(int OrderId)
        {
            ReadOrderByIdDto? order = ordermanager.GetOrderById(OrderId);
            if (order == null) { return NotFound(); }
            return Ok(order);
        }
        #endregion
    }
}
