using AirflightsDataAccess.Entities;
using AirflightsDomain.Models.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirflightsDataAccess.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, AuthUserDTO>()
                .ForMember("Roles", opt => opt.MapFrom(c => c.UserRoles.Select(r => r.Role.Code)));
            CreateMap<CreateUserDTO, User>();
        }
    }
}
