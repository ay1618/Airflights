using AirflightsDataAccess.Entities;
using AirflightsDomain.Models.Flight;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Profiles
{
    public class FlightProfile: Profile
    {
        public FlightProfile() {
            CreateMap<Flight, FlightDTO>();
        }
    }
}
