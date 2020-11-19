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
        Task<AuthUserDTO> GetAuthAsync(string login);

        Task CreateAsync(CreateUserDTO user);
    }
}
