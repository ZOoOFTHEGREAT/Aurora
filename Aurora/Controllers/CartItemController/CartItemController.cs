using AuroraBLL.Dtos;
using AuroraBLL.Dtos.CartDtos;
using AuroraBLL.Dtos.CartItemDtos;
using AuroraBLL.Managers.CartItemManager;
using AuroraBLL.Managers.OrderItemManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers.CartItemController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {

        #region Inject
        private readonly ICartItemManager _cartItemMnagaer;

        public CartItemController(ICartItemManager cartItemManager) {
        
        _cartItemMnagaer = cartItemManager;
        }
        #endregion

        #region Get Cart Item By Cart Id
        [HttpGet]
        [Route("{cartId}")]
        public ActionResult<List<ReadCartItemDto>>? GetByCartId(int cartId) {

            IEnumerable<ReadCartItemDto>? readCartItemDto = _cartItemMnagaer.GetCartItemsByCartId(cartId).ToList();
            if (readCartItemDto is null) 
            { 
            return NotFound();
            }
            return Ok(readCartItemDto);
        }
        #endregion

        #region get cart item detail
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadCartItemDetailDto> GetById(int id) {
            ReadCartItemDetailDto? readCartItemDetailDto = _cartItemMnagaer.readCartItemDetailDto(id);
            if (readCartItemDetailDto is null) {
                return BadRequest();
            }
            return readCartItemDetailDto;   
        
        }
        #endregion

        #region Add cart item
        [HttpPost]
        public ActionResult Add(AddCartItemDto addCartItemDto)
        {
            if (addCartItemDto is null)
            {
                return NotFound(addCartItemDto);
            }

            var AddedCartItem = _cartItemMnagaer.AddCartItem(addCartItemDto);
            return CreatedAtAction(nameof(Add), AddedCartItem);
        }
        #endregion

        #region Update
        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(UpdateCartItemDto updateCartItemDto) {

           var isFound = _cartItemMnagaer.Update(updateCartItemDto);
            if (!isFound)
            {
                return NotFound(updateCartItemDto);

            }
            return Ok(updateCartItemDto);

        }
        #endregion

        #region delete cart item 
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCartItem(int id)
        {

            var isFound = _cartItemMnagaer.IsDelete(id);
            if (!isFound)
            {
                return NotFound();
            }
            return Ok(NoContent());
        }
        #endregion

    }



}
    

