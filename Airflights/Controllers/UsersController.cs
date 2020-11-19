using AirflightsDomain.Models.User;
using AirflightsDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airflights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;

        /// <summary>
        /// конструктор - точка входа внедрения сервисов
        /// </summary>
        /// <param name="usersService">сервис для пользователей</param>
        public UsersController(IUserService usersService)
        {
            this._usersService = usersService;
        }

        /// <summary>
        /// создание нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // PUT api/users
        [HttpPut]
        public async Task Put([FromBody] CreateUserDTO user)
        {
            await _usersService.CreateAsync(user);
        }
    }
}
