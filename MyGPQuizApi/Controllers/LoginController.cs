using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.AuthModel;
using Services;

namespace MyGPQuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Jwtservice _jwts;

        public LoginController(Jwtservice jwts)
        {
            _jwts = jwts;
        }
        [HttpPost]
        //public Task<IActionResult> Post(LoginModel _userData)
        //{
        //    try
        //    {
        //        object? token = _jwts.GenerateToken();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

    //}
}
