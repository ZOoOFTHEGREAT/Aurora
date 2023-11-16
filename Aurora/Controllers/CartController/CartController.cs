using AuroraBLL.Dtos;
using AuroraBLL.Dtos.CartDtos;
using AuroraBLL.Dtos.OrderItemDtos;
using AuroraBLL.Managers.CartManager;
using AuroraBLL.Managers.OrderItemManager;
using AuroraDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers.CartController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        #region Inject
        private readonly ICartManager _cartManager;

        public CartController(ICartManager cartManager) {
            _cartManager = cartManager;

        }
        #endregion

        #region Add Cart
        [HttpPost]

        public ActionResult Add(AddCartDto addCartDto) {
            if (addCartDto is null)
            {
                return NotFound(addCartDto);
            }

            var AddedCart = _cartManager.AddCart(addCartDto);
            return CreatedAtAction(nameof(Add), AddedCart);
        }
        #endregion

        #region Get All
        [HttpGet]
        public ActionResult<List<ReadCartDto>> GetAll() {

            return _cartManager.GetAll().ToList();
        }
        #endregion

        #region Get By User Id
        [HttpGet]
        [Route("{userId}")]
        public ActionResult<ReadCartDetailDto> GetByUserId(String userId) {
            ReadCartDetailDto? readCartDetailDto = _cartManager.GetCartByUserId(userId);
            if (readCartDetailDto is null) { 
                return NotFound(readCartDetailDto);
            
            }
            return Ok(readCartDetailDto);
        }
        #endregion
    }
}
