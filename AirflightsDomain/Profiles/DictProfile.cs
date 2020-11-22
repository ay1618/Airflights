using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Profiles
{
    public class DictProfile: Profile
    {
        public DictProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();
        }
    }
}
