using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Profiles
{
    public class DictProfile: Profile
    {
        public DictProfile()
        {
            CreateMap<City, CityDTO>();
        }
    }
}
