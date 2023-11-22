using AuroraBLL.Dtos.UserDtos;
using AuroraBLL.Managers.UserManager;
using AuroraDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManger userManger;

        public UserController(IUserManger userManger)
        {
            this.userManger = userManger;
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUserByIdDto> GetById(string id)
        {
            if (id == "")
                return BadRequest();

            var user = userManger.GetUserById(id);

            if (user == null)
                return NotFound();

            return CreatedAtAction("GetById",user);
        }

        //[Authorize(Policy = "ManagerPolicy")]
        [HttpGet]
        [Route("email/{email}")]
        public ActionResult<ReadUserByEmailDto> GetUserByEmail(string email)
        {
            if (email == "")
                return BadRequest();

            var user = userManger.GetUserByEmail(email);

            if (user == null)
                return NotFound();

            return CreatedAtAction("GetUserByEmail", user);
        }
        [HttpGet]
        [Route("phone/{phoneNum}")]
        public ActionResult<ReadUserByPhoneNumberDto> GetUserByPhoneNumber(string phoneNum)
        {
            if (phoneNum == "")
                return BadRequest();

            var user = userManger.GetUserByPhoneNumber(phoneNum);

            if (user == null)
                return NotFound();

            return CreatedAtAction("GetUserByPhoneNumber", user);
        }
        [Authorize]
        [HttpGet]
        [Route("details/{id}")]
        public ActionResult<ReadUserDetailsByIdDto> GetDetailsById(string id)
        {
            if(id == "")
                return BadRequest();

            var user = userManger.GetUserDetailsById(id);

            if (user == null)
                return NotFound();

            return CreatedAtAction("GetDetailsById", user);
        }

        [HttpPost]
        public ActionResult Add(AddUserDto userDto)
        {
            if (userDto == null)
                return NotFound();

            var userSaved = userManger.Add(userDto);

            if(userSaved == 0)
                return BadRequest();

            return CreatedAtAction("Add", userDto);
        }

        [HttpPut]
        public ActionResult<UpdateUserDto> Updated(UpdateUserDto userDto)
        {
            if (userDto.Id == "")
                return NotFound();

            var userUpdated = userManger.IsUpdated(userDto);

            if (userUpdated == false)
                return BadRequest();

            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string userId)
        {
            if (userId == "")
                return NotFound();
            var userDeleted = userManger.IsDeleted(userId);

            if (userDeleted == false)
                return BadRequest();
            return NoContent();
        }
    }
}
