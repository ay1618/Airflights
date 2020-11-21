using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Flight
{
    public class FlightFilterRequestDTO
    {
        public int? From { get; set; }
        public int? To { get; set; }
        public DateTime? DepartureTimeFrom { get; set; }
        public DateTime? DepartureTimeUntil { get; set; }
        //public DateTime? ArrivalTimeFrom { get; set; }
        //public DateTime? ArrivalTimeUntil { get; set; }
    }
}
