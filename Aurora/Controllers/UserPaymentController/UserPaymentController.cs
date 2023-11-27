using AuroraBLL.Dtos.UserPaymentDtos;
using AuroraBLL.Managers.UserPaymentManager;
using Microsoft.AspNetCore.Mvc;


namespace AuroraAPI.Controllers.UserPaymentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaymentController : ControllerBase
    {
        private readonly IUserPaymentManager userPaymentManager;

        public UserPaymentController(IUserPaymentManager userPaymentManager)
        {
            this.userPaymentManager = userPaymentManager;
        }

        [HttpGet("byuser/{userid}")]
            public ActionResult<ReadUserPaymentByUserIdDto> GetByUserId(string userid)
        {
            if (userid == "")
                return BadRequest();

            var userPayment = userPaymentManager.GetUserPaymentByUserId(userid);

            if (userPayment == null)
                return NotFound();

            return Ok(userPayment);
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUserPaymentDetailDto> GetById(int id)
        {
            if (id == 0)
                return BadRequest();
            var userPayment = userPaymentManager.GetById(id);

            if (userPayment == null)
                return NotFound();
            return Ok(userPayment);
        }

        [HttpPost]
        public ActionResult<AddUserPaymentDto> Add(AddUserPaymentDto userPaymentDto)
        {
            if (userPaymentDto == null)
                return NotFound();

            var userPayment = userPaymentManager.Add(userPaymentDto);

            if (userPayment == 0)
                return BadRequest();

            return CreatedAtAction("Add", userPaymentDto);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();
            var userPaymentDeleted = userPaymentManager.IsDeleted(id);

            if (userPaymentDeleted == false)
                return BadRequest();

            return NoContent();
        }
    }
}
