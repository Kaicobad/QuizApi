using DAL;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Jwtservice
    {
        private readonly IConfiguration _Congiguration;


        public Jwtservice(IConfiguration congiguration)
        {
            _Congiguration = congiguration;
        }
        public object GenerateToken(UserInfoModel _Usermodel)
        {
            if (_Usermodel.PhoneNumber != null )
            {
                var user = GetUser(_Usermodel.PhoneNumber);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _Congiguration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("PhoneNumber", user.Select(u => u.PhoneNumber).ToString()),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Congiguration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _Congiguration["Jwt:Issuer"],
                        _Congiguration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return ("Invalid credentials");
                }
            }
            else
            {
                return ("Invalid credentials");
            }
        }

        //public object GenerateToken()
        //{
        //    throw new NotImplementedException();
        //}

        private string Ok(string v)
        {
            throw new NotImplementedException();
        }

        private List<UserInfoModel> GetUser(string phoneNumber)
        {
            UserInfoService sv = new UserInfoService();
            var list = sv.GetAll().Select(u => u.PhoneNumber = phoneNumber);

            return (List<UserInfoModel>)list;
        }
    }
}
