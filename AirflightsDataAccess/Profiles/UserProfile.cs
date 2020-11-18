using AirflightsDataAccess.Entities;
using AirflightsDomain.Models.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
