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
        [HttpPost]
        public IActionResult InsertUser(UserInfoModel employeeModel)
        {
            try
            {
                var model = _IUserInfo.Insert(employeeModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
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
        [HttpGet]
        public List<UserInfoModel> GetAll()
        {
            try
            {
                //var list = _IUserInfo.GetAll();
                return _IUserInfo.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
