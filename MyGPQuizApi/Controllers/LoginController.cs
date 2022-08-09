using Entities;
using Entities.AuthModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyGPQuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public UserInfoModel userinfo = new UserInfoModel();
        public UserInfoService userinfoService = new UserInfoService();

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var msidn = Authenticate(loginModel);

            if (msidn != null)
            {
                var token = Gnenerate(msidn);
                return Ok (token);
            }
            return BadRequest();
        }

        private string Gnenerate(UserInfoModel userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userinfo.PhoneNumber)
            };

            var token = new JwtSecurityToken
                (
                    configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                 );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private UserInfoModel? Authenticate(LoginModel loginModel)
        {
            var msidn = userinfoService.GetAll().FirstOrDefault(o => o.PhoneNumber == loginModel.msidn);
            if (msidn != null)
            {
                return msidn;
            }
            return null;
        }
    }
}
