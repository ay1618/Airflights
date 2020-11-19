using AirflightsDomain.Models.Entities;
using AirflightsDomain.Models.User;
using AirflightsDomain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRep;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRep, IMapper mapper)
        {
            this._userRep = userRep;
            this._mapper = mapper;
        }

        public async Task<AuthUserDTO> GetIdentityAsync(string login, string password)
        {
            User userEntity = await _userRep.GetAuthAsync(login);
            AuthUserDTO user = _mapper.Map<AuthUserDTO>(userEntity);
            if (user is null)
                return null;

            PasswordHasher<AuthUserDTO> passwordHasher = new PasswordHasher<AuthUserDTO>();
            PasswordVerificationResult verifyResult = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (verifyResult == PasswordVerificationResult.Failed)
                return null;

            return user;
        }

        public async Task CreateAsync(CreateUserDTO newUser)
        {
            PasswordHasher<CreateUserDTO> passwordHasher = new PasswordHasher<CreateUserDTO>();
            newUser.Password = passwordHasher.HashPassword(newUser, newUser.Password);
            User user = _mapper.Map<User>(newUser);
            await _userRep.CreateAsync(user);
        }
    }
}
