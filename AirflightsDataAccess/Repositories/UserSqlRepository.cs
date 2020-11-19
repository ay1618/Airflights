using AirflightsDataAccess.Entities;
using AirflightsDomain.Models.User;
using AirflightsDomain.Repositories;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserSqlRepository(ApplicationContext context, IMapper mapper)
        {
            _applicationContext = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateUserDTO user)
        {
            User newUser = _mapper.Map<User>(user);
            await _applicationContext.AddAsync<User>(newUser);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<AuthUserDTO> GetAuthAsync(string login)
        {
            User user = await _applicationContext.Users.Include(u => u.UserRoles).FirstOrDefaultAsync(u => u.Login == login);
            return _mapper.Map<AuthUserDTO>(user);
        }
    }
}
