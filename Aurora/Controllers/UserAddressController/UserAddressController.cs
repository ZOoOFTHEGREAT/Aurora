using AuroraBLL.Dtos.UserAddressDtos;
using AuroraBLL.Managers.UserAddressManager;
using AuroraBLL.Managers.UserManager;
using AuroraDAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace AuroraAPI.Controllers.UserAddressController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressManager userAddressManager;

        public UserAddressController(IUserAddressManager userAddressManager)
        {
            this.userAddressManager = userAddressManager;
        }

        [HttpGet]
        [Route("userid/{id}")]
        public ActionResult<List<ReadUserAddresByUserIdDto>> GetAddressByUserId(string id)
        {
            if (id == "")
                return BadRequest();
            var userAddres = userAddressManager.GetAddressByUserId(id);
            if (userAddres is null)
                return NotFound();

            return Ok(userAddres);
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUserAddressDetailDto> GetById(int id)
        {
            if (id == 0)
                return BadRequest();
            var userAddress = userAddressManager.GetById(id);

            if (userAddress == null)
                return NotFound();
            return Ok(userAddress);
        }

        [HttpPost]
        public ActionResult<AddUserAddressDto> Add(AddUserAddressDto userAddressDto)
        {
            if (userAddressDto == null)
                return NotFound();

            var userPayment = userAddressManager.Add(userAddressDto);

            if (userPayment == 0)
                return BadRequest();

            return CreatedAtAction("Add", userAddressDto);
        }

        [HttpPut("{id}")]
        public ActionResult<UpdateUserAddressDto> Put(UpdateUserAddressDto updateUserAddress)
        {
            if (updateUserAddress.Id == 0)
                return NotFound();

            var userAddressUpdated = userAddressManager.IsUpdated(updateUserAddress);

            if (userAddressUpdated == false)
                return BadRequest();
           
            return Ok(userAddressUpdated);
        }

        [HttpDelete("{id}")]
        public ActionResult<UpdateUserAddressDto> Delete(int id)
        {
            if (id == 0)
                return NotFound();
            var userAddressDeleted = userAddressManager.IsDeleted(id);

            if (userAddressDeleted == false)
                return BadRequest();
            return NoContent();
        }
    }
}
