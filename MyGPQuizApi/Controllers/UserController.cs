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
    }
}
