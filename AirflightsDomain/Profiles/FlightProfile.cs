using AirflightsDomain.Models.Entities;
using AirflightsDomain.Models.Flight;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Profiles
{
    public class FlightProfile: Profile
    {
        public FlightProfile() {
            CreateMap<Flight, FlightDTO>();
            CreateMap<CreateFlightDTO, Flight>();
            CreateMap<UpdateFlightDTO, Flight>();
            CreateMap<UpdateFlightDelayDTO, Flight>();
        }
    }
}
