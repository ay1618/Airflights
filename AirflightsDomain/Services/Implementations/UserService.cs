using AirflightsDomain.Models.User;
using AirflightsDomain.Repositories;
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

        public UserService(IUserRepository userRep)
        {
            this._userRep = userRep;
        }

        public async Task<AuthUserDTO> GetIdentityAsync(string login, string password)
        {
            AuthUserDTO user = await _userRep.GetAuthAsync(login);
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
            await _userRep.CreateAsync(newUser);
        }
    }
}
