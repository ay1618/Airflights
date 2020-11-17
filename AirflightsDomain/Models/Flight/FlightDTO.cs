using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Flight
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public CityDTO From { get; set; }
        public CityDTO To { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Delay { get; set; }
        public int UserId { get; set; }
    }
}
