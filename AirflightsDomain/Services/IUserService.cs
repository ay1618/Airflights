using AirflightsDomain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Services
{
    public interface IUserService
    {
        Task<AuthUserDTO> GetIdentityAsync(string login, string password);

        Task CreateAsync(CreateUserDTO newUser);
    }
}
