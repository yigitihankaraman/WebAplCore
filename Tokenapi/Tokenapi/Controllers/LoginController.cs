using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Tokenapi.Model;

namespace Tokenapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]LoginDTO credentials)
        {
            var user = UserList.SingleOrDefault(x => x.Username == credentials.Username && x.Password == credentials.Password);
            if (user == null) return Ok(new { Hata = "Gerçersiz Kullanıcı veya Şifre" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "SomeCustomApp",
                Issuer = "yk.api.demo",
                
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credentials.Username),
                    //new Claim(ClaimTypes.HomePhone,"+90 555 123 45 67"),
                    new Claim("Password", credentials.Password)
                }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddSeconds(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        private List<LoginDTO> UserList = new List<LoginDTO>
        {
            new LoginDTO { Username = "yigit", Password= "123456" },
            new LoginDTO { Username = "yigit1", Password= "12345" },
            new LoginDTO { Username = "yigit2", Password= "1234" },
            new LoginDTO { Username = "yigit3", Password= "123" },
        };
    }
}