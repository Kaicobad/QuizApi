using Entities;
using Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        //public UserInfoModel GetCurrentUser()
        //{
        //    var Identity = HttpContext.User.Identity as ClaimsIdentity;
        //    if (Identity != null)
        //    {
        //        var userClaims = Identity.Claims;

        //        var userPhone = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;

        //        var userDetailsAsClaims = _IUserInfo.GetAll().FirstOrDefault(o => o.PhoneNumber == userPhone);

        //        return new UserInfoModel
        //        {
        //            UserId = userDetailsAsClaims.UserId,
        //            UserName = userDetailsAsClaims.UserName,
        //            ImageUrl = userDetailsAsClaims.ImageUrl,
        //            PhoneNumber = userDetailsAsClaims.PhoneNumber,
        //            Gender = userDetailsAsClaims.Gender,
        //            DateOfBirth = userDetailsAsClaims.DateOfBirth,
        //            CreatedDate = userDetailsAsClaims.CreatedDate,
        //            ModifiedDate = userDetailsAsClaims.ModifiedDate
        //        };
        //    }
        //    return null;
        //}
    }
}
