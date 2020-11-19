using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using AirflightsDomain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAuthAsync(string login);

        Task CreateAsync(User user);

        Task<int> GetUserIdByLoginAsync(string login);
    }
}
