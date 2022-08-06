using Entities;
using Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyGPQuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInfo _IUserInfo;

        public UserController(IUserInfo iuserInfo)
        {
            _IUserInfo = iuserInfo;
        }
        [HttpPost("insertUser")]
        public IActionResult InsertUser(UserInfoModel employeeModel)
        {
            try
            {
                var model = _IUserInfo.Insert(employeeModel);
                return Ok(new { statusCode = 200, message = "User Added" });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("updateUser")]
        public IActionResult UpdateUser(UserInfoModel employeeModel)
        {
            try
            {
                var model = _IUserInfo.Update(employeeModel);
                return Ok(new { statusCode = 200, message = "User Updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser(UserInfoModel employeeModel)
        {
            try
            {
                var model = _IUserInfo.Delete(employeeModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("getallUser")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _IUserInfo.GetAll();
                //return _IUserInfo.GetAll();

                return Ok(new { statusCode = 200, message = "success", value = list });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
