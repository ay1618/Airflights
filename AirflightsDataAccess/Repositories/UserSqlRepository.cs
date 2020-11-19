using AirflightsDomain.Models.Entities;
using AirflightsDomain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDataAccess.Repositories
{
    public class UserSqlRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UserSqlRepository(ApplicationContext context)
        {
            _applicationContext = context;
        }

        public async Task CreateAsync(User user)
        {
            await _applicationContext.AddAsync<User>(user);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<User> GetAuthAsync(string login)
            => await _applicationContext.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Login == login);

        public async Task<int> GetUserIdByLoginAsync(string login) 
            => (await _applicationContext.Users
                .FirstOrDefaultAsync(
                    u => u.Login == login
                 )).Id;

    }
}
