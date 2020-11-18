using AirflightsDomain.Models;
using AirflightsDomain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetAsync(string login, string password);

        Task CreateAsync(CreateUserDTO user);
    }
}
