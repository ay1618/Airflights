using AirflightsDomain.Models.User;
using AirflightsDomain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Airflights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : _BaseController//ControllerBase
    {
        private readonly IUserService _usersService;
        private readonly IConfiguration _config;

        /// <summary>
        /// конструктор - точка входа внедрения сервисов
        /// </summary>
        /// <param name="usersService">сервис для пользователей</param>
        /// <param name="config">для получение конфиг данных с appsettings</param>
        public AuthController(IUserService usersService, IConfiguration config)
        {
            this._usersService = usersService;
            this._config = config;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserRequestDTO userReq)
        {
            var user = await _usersService.GetIdentityAsync(userReq.Login, userReq.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["authSettings:Secret"]);
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                };

            foreach (string role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;


            return Ok(user);
        }
    }
}
